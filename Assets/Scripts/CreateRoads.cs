using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using EasyRoads3Dv3;

public class CreateRoads : MonoBehaviour
{

	private float min_lon;
	// Min lon of the bounding box
	private float min_lat;
	// Min lat of the bounding box
	private float max_lon;
	// Max lon of the bounding box
	private float max_lat;
	// Max lot of the bounding box
	private float boxWidth;
	// Height of the bounding box in meters
	private float boxHeight;
	// Width of the bounding box in meters
	private List<ERRoad> roads;
	// A list of all the roads in the scene
	private List<ERRoad> currentThreadRoads;
	// List of roads on the current download thread, necessary since data
	// Is downloaded in tiles

	public ERRoadNetwork roadNetwork; // The roadnetword object from EasyRoads3D
	public ERRoadType roadType;
	public ERConnection connection;

	// Use this for initialization
	void Start ()
	{
		roads = new List<ERRoad> ();
		roadNetwork = new ERRoadNetwork ();
		roadType = new ERRoadType();
		roadType.roadWidth = 6;
		roadType.roadMaterial = Resources.Load("Materials/roads/single lane") as Material;
		roadType.connectionMaterial = Resources.Load ("Materials/crossings/crossing material") as Material;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
		
	// Receive the JSON results from the Mapzen download
	// Parse the JSON to create road objects using EasyRoads3D
	public void ReceiveDownloadResults (string results)
	{
		var json = JSON.Parse (results);
		JSONArray roadFeatures = json ["roads"] ["features"].AsArray;
		currentThreadRoads = new List<ERRoad> ();
		for (int i = 0; i < roadFeatures.Count; i++) {
			string type = roadFeatures [i] ["geometry"] ["type"].Value;
			if (type == "LineString") {
				JSONArray coordinates = roadFeatures [i] ["geometry"] ["coordinates"].AsArray;
				Vector3[] roadMarkers = parseLineString (coordinates);
				string time = System.DateTime.Now.ToUniversalTime ().ToString ();
				ERRoad road = roadNetwork.CreateRoad ("Road " + time, roadType, roadMarkers);
				addRoad (road);
			} else if (type == "MultiLineString") {
				JSONArray coordinates = roadFeatures [i] ["geometry"] ["coordinates"].AsArray;
				for (int j = 0; j < coordinates.Count; j++) {
					JSONArray coords = coordinates [j].AsArray;
					Vector3[] roadMarkers = parseLineString (coords);
					string time = System.DateTime.Now.ToUniversalTime().ToString();
					ERRoad road = roadNetwork.CreateRoad ("Multiline " + time, roadType, roadMarkers);
					addRoad (road);
				}
			}
		}
	}

	// Adds a road, checking connections/intersections
	// Attempts to reduce chopiness in road merging
	// Uses road merging technique mentioned in Chris Hay's independent work
	// If angle < 30 degrees, connect roads as one
	void addRoad(ERRoad toAdd) {
		for (int i = 0; i < currentThreadRoads.Count; i++) {
			ERRoad existing = currentThreadRoads [i];
			Vector3 sharedPos = shareNode (existing, toAdd);
			ERConnection[] conns = roadNetwork.LoadConnections ();
			if (sharedPos.y >= 0) {
				//ERConnection conn = roadNetwork.InstantiateConnection(conns[10], "conn", sharedPos, new Vector3(0.0f, 0.0f));
				//toAdd.ConnectToEnd (conn,0);
			}
		}
		currentThreadRoads.Add (toAdd);
	}

	// Checks if two roads share a node
	Vector3 shareNode(ERRoad road1, ERRoad road2) {
		Vector3[] markers1 = road1.GetMarkerPositions ();
		Vector3[] markers2 = road2.GetMarkerPositions ();
		// bool share = false;
		foreach(Vector3 v1 in markers1) {
			foreach (Vector3 v2 in markers2) {
				if (vectorsCloseEqual (v1, v2)) {
					return v2;
				}
			}
		}
		return new Vector3(0, -100, 0);
	}

	// Check if two position vectors are close enough to be considered equal. For checking
	// If roads share nodes, in order to connect them. Considered close enough if the elements are all within
	// 0.5f of each other
	bool vectorsCloseEqual(Vector3 v1, Vector3 v2) {
		return (Mathf.Abs (v1.x - v2.x) <= 0.5f && Mathf.Abs (v1.y - v2.y) <= 0.5f && Mathf.Abs (v1.z - v2.z) <= 0.5f);
	}

	// Call functions that pertain to finishing the construction of a road network
	public void finishBuilding() {
		roadNetwork.HideWhiteSurfaces (true);
		roadNetwork.BuildRoadNetwork ();
	}

	// Converts from radians to degrees
	float toDegrees(float radians) {
		return radians * 180 / Mathf.PI;
	}

	// Recive a JSON array which represents the cooridnates of nodes in a road
	// Use that array to create EasyRoads3D
	Vector3[] parseLineString(JSONArray coordinates) {
		Vector3[] markers = new Vector3[coordinates.AsArray.Count];
		for (int j = 0; j < coordinates.Count; j++) {
			float zCoord = longToZCoord(coordinates [j] [0].AsFloat);
			float xCoord = latToXCoord(coordinates [j] [1].AsFloat);
			Vector3 vector = new Vector3 (xCoord, 0, zCoord);
			GameObject cube = GameObject.CreatePrimitive (PrimitiveType.Cube);
			cube.transform.position = new Vector3(vector.x, Random.Range(0, 10), vector.z);
			markers [j] = vector;
		}
		return markers;
	}

	// Calculate the Unity z coordinate from a longitude
	// Uses the bottom left of the bounding box as the origin of the coordinate system
	// AKA, a point at (minLong, minLat) would have a Unity position of (0, 0, 0)
	// A point at (maxLong, minlat) would have a Unity position of (0, 0, Z) where Z is what is being 
	// Calculated in this function
	float longToZCoord(float longitude) {
		float distance = distanceBetweenTwoPoints (min_lat, min_lon, min_lat, longitude);
		if (longitude < min_lon) {
			distance *= -1;
		}
		return distance;
	}

	// Calculate the Unity x coordinate from a latitude
	// Same coordinate system as the one for longToZCoord
	float latToXCoord(float latitude) {
		float distance = distanceBetweenTwoPoints (min_lat, min_lon, latitude, min_lon);
		if (latitude < min_lat) {
			distance *= -1;
		}
		return distance;
	}
	
	// Receive and store the bounding box of the openstreetmap query for use in calculating distances for rendering roads
	// Also calculate height and width of bounding box, in meters
	public void storeBoundingBox (float min_long, float min_lat, float max_long, float max_lat)
	{
		this.min_lon = min_long;
		this.min_lat = min_lat;
		this.max_lon = max_long;
		this.max_lat = max_lat;
		calculateWidthAndHeightOfBBox ();
	}

	// Returns the distance between two latitudes and longitudes, in meters.
	// Using the haversine formula
	// http://andrew.hedges.name/experiments/haversine/
	float distanceBetweenTwoPoints (float lat1, float lon1, float lat2, float lon2)
	{
		float radius = 6371e3f;	
		float dlon = toRadians (lon2) - toRadians (lon1);
		float dlat = toRadians (lat2) - toRadians (lat1);
		float a = Mathf.Pow(Mathf.Sin(dlat/2), 2);
		a += Mathf.Cos(toRadians(lat1)) * Mathf.Cos(toRadians(lat2)) * Mathf.Pow(Mathf.Sin(dlon/2),2);
		float c = 2 * Mathf.Atan2 (Mathf.Sqrt (a), Mathf.Sqrt (1 - a));
		float distance = radius * c;
		return distance;

	}

	// Calculate and store width and height of bounding box
	void calculateWidthAndHeightOfBBox ()
	{ 
		boxWidth = distanceBetweenTwoPoints (min_lat, min_lon, min_lat, max_lon);
		boxHeight = distanceBetweenTwoPoints (max_lat, min_lon, min_lat, min_lon);

	}

	// Helper method for converting degrees to radians
	float toRadians (float degrees)
	{
		return degrees * Mathf.PI / 180 ;
	}
}