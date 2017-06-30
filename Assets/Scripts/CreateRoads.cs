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

	public ERRoadNetwork roadNetwork; // The roadnetword object from EasyRoads3D
	public ERRoad road;				// The Road object from EasyRoads3D
	public ERRoadType roadType;

	// Use this for initialization
	void Start ()
	{
		roads = new List<ERRoad> ();
		roadNetwork = new ERRoadNetwork ();
		roadType = new ERRoadType();
		roadType.roadWidth = 6;
		roadType.roadMaterial = Resources.Load("Materials/roads/single lane") as Material;
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
		for (int i = 0; i < roadFeatures.Count; i++) {
			string type = roadFeatures [i] ["geometry"] ["type"].Value;
			if (type == "LineString") {
				JSONArray coordinates = roadFeatures [i] ["geometry"] ["coordinates"].AsArray;
				Vector3[] roadMarkers = parseLineString (coordinates);
				ERRoad road = roadNetwork.CreateRoad ("Road", roadType, roadMarkers);
				roads.Add (road);
			} else if (type == "MultiLineString") {
				JSONArray coordinates = roadFeatures [i] ["geometry"] ["coordinates"].AsArray;
				for (int j = 0; j < coordinates.Count; j++) {
					JSONArray coords = coordinates [j].AsArray;
					Vector3[] roadMarkers = parseLineString (coords);
					ERRoad road = roadNetwork.CreateRoad ("Multiline", roadType, roadMarkers);
					roads.Add (road);
				}
			}
		}

	}

	// Tries to connect road objects to reduce choppiness of road network
	public void connectRoads() {
		Debug.Log (roads.Count);
		//roadNetwork.ConnectRoads (roads [14], roads [25]);
		for (int i = 0; i < roads.Count-1; i++) {
			//roadNetwork.ConnectRoads (roads [i], roads [i + 1]);
		}
		roadNetwork.HideWhiteSurfaces (true);
		roadNetwork.BuildRoadNetwork ();
	}

	// Recive a JSON array which represents the cooridnates of nodes in a road
	// Use that array to create EasyRoads3D
	Vector3[] parseLineString(JSONArray coordinates) {
		Vector3[] markers = new Vector3[coordinates.AsArray.Count];
		for (int j = 0; j < coordinates.Count; j++) {
			float zCoord = longToZCoord(coordinates [j] [0].AsFloat);
			float xCoord = latToXCoord(coordinates [j] [1].AsFloat);
			Vector3 vector = new Vector3 (xCoord, 0, zCoord);
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
		boxWidth = distanceBetweenTwoPoints (1.0f, min_lon, 1.0f, max_lon);
		boxHeight = distanceBetweenTwoPoints (max_lat, min_lon, min_lat, min_lon);
	}

	// Helper method for converting degrees to radians
	float toRadians (float degrees)
	{
		return degrees * Mathf.PI / 180 ;
	}


}
