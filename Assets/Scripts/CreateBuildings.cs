using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class CreateBuildings : MonoBehaviour {

	List<List<Vector3>> buildingVertices = new List<List<Vector3>> ();
	// A list of lists of vertices that make up each building
	List<float> buildingHeights = new List<float>();

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Receive the GeoJSON data from Mapzen, parse for buildings
	public void receiveData(string results) {
		var json = JSON.Parse (results);
		JSONArray buildingFeatures = json ["buildings"] ["features"].AsArray;
		for (int i = 0; i < buildingFeatures.Count; i++) {
			JSONArray building = buildingFeatures [i] ["geometry"] ["coordinates"].AsArray;
			string kindOfBuilding = buildingFeatures [i]["geometry"] ["type"].Value;
			if (kindOfBuilding == "Polygon") {
				JSONArray coordArray = building [0].AsArray;
				// Create the list of vertices for this building (building[i])
				List<Vector3> vertices = new List<Vector3> ();
				for (int j = 0; j < coordArray.Count; j++) {
					float xCoord = Calc.latToXCoord (coordArray [j] [1].AsFloat);
					float zCoord = Calc.longToZCoord (coordArray [j][0].AsFloat);
					Vector3 loc = new Vector3 (xCoord, 0.0f, zCoord);
					vertices.Add (loc);
				}
				// Add building[i] to the list of buildings
				buildingVertices.Add (vertices);
				Debug.Log(buildingFeatures[i]["properties"]["height"].Value);

			}
		}
	}
}
