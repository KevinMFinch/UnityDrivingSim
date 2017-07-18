using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using EasyRoads3Dv3;

public class CreateRoads : MonoBehaviour
{
	
	private List<ERRoad> roads;
	// A list of all the roads in the scene
	private List<ERRoad> currentThreadRoads;
	// List of roads on the current download thread, necessary since data
	// Is downloaded in tiles

	public ERRoadNetwork roadNetwork;
	// The roadnetword object from EasyRoads3D
	public ERRoadType roadType;
	public ERConnection connection;

	// Use this for initialization
	void Start ()
	{
		roads = new List<ERRoad> ();
		roadNetwork = new ERRoadNetwork ();
		roadType = new ERRoadType ();
		roadType.roadWidth = 6;
		roadType.roadMaterial = Resources.Load ("Materials/roads/single lane") as Material;
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
			string kindOfRoad = roadFeatures [i] ["properties"] ["kind"].Value;
			string nameOfRoad = roadFeatures [i] ["properties"] ["name"].Value;
			if (kindOfRoad != "path") {
				if (type == "LineString") {
					JSONArray coordinates = roadFeatures [i] ["geometry"] ["coordinates"].AsArray;
					Vector3[] roadMarkers = parseLineString (coordinates);
					ERRoad road = roadNetwork.CreateRoad (nameOfRoad, roadType, roadMarkers);
					addRoad (road);
				} else if (type == "MultiLineString") {
					JSONArray coordinates = roadFeatures [i] ["geometry"] ["coordinates"].AsArray;
					for (int j = 0; j < coordinates.Count; j++) {
						JSONArray coords = coordinates [j].AsArray;
						Vector3[] roadMarkers = parseLineString (coords);
						ERRoad road = roadNetwork.CreateRoad (nameOfRoad, roadType, roadMarkers);
						addRoad (road);
					}
				}
			}
		}
	}

	// Adds a road, checking connections/intersections
	// Attempts to reduce chopiness in road merging
	// Uses road merging technique mentioned in Chris Hay's independent work
	// If angle < 30 degrees, connect roads as one
	// ****This isn't actually doing anything right now
	void addRoad (ERRoad toAdd)
	{
		/* for (int i = 0; i < currentThreadRoads.Count; i++) {
			ERRoad existing = currentThreadRoads [i];
			Vector3 sharedPos = shareNode (existing, toAdd);
			ERConnection[] conns = roadNetwork.LoadConnections ();
			if (sharedPos.y >= 0) {
				//ERConnection conn = roadNetwork.InstantiateConnection(conns[10], "conn", sharedPos, new Vector3(0.0f, 0.0f));
				//toAdd.ConnectToEnd (conn,0);
			}
		}*/
		currentThreadRoads.Add (toAdd);
	}

	// Checks if two roads share a node
	Vector3 shareNode (ERRoad road1, ERRoad road2)
	{
		Vector3[] markers1 = road1.GetMarkerPositions ();
		Vector3[] markers2 = road2.GetMarkerPositions ();
		// bool share = false;
		foreach (Vector3 v1 in markers1) {
			foreach (Vector3 v2 in markers2) {
				if (vectorsCloseEqual (v1, v2)) {
					return v2;
				}
			}
		}
		return new Vector3 (0, -100, 0);
	}

	// Check if two position vectors are close enough to be considered equal. For checking
	// If roads share nodes, in order to connect them. Considered close enough if the elements are all within
	// 0.5f of each other
	bool vectorsCloseEqual (Vector3 v1, Vector3 v2)
	{
		return (Mathf.Abs (v1.x - v2.x) <= 0.5f && Mathf.Abs (v1.y - v2.y) <= 0.5f && Mathf.Abs (v1.z - v2.z) <= 0.5f);
	}

	// Call functions that pertain to finishing the construction of a road network
	public void finishBuilding ()
	{
		roadNetwork.HideWhiteSurfaces (true);
		roadNetwork.BuildRoadNetwork ();
	}

	// Recive a JSON array which represents the cooridnates of nodes in a road
	// Use that array to create EasyRoads3D
	Vector3[] parseLineString (JSONArray coordinates)
	{
		Vector3[] markers = new Vector3[coordinates.AsArray.Count];
		for (int j = 0; j < coordinates.Count; j++) {
			float zCoord = Calc.longToZCoord (coordinates [j] [0].AsFloat);
			float xCoord = Calc.latToXCoord (coordinates [j] [1].AsFloat);
			Vector3 vector = new Vector3 (xCoord, 0, zCoord);
			markers [j] = vector;
		}
		return markers;
	}

}