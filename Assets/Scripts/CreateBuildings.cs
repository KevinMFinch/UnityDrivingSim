using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class CreateBuildings : MonoBehaviour {

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
				for (int j = 0; j < coordArray.Count; j++) {
					float longi = coordArray [j][0].AsFloat;
					float lati = coordArray [j] [1].AsFloat;

				}
			}
		}
	}
}
