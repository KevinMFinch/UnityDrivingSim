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
				float height = Random.Range (15, 60);
				for (int j = 0; j < coordArray.Count; j++) {
					float xCoord = Calc.latToXCoord (coordArray [j] [1].AsFloat);
					float zCoord = Calc.longToZCoord (coordArray [j][0].AsFloat);
					Vector3 loc = new Vector3 (xCoord, 0.0f, zCoord);
					Vector3 skyLoc = new Vector3 (xCoord, height, zCoord);
					vertices.Add (loc);
					vertices.Add (skyLoc);
				}
				// Add building[i] to the list of buildings
				buildingVertices.Add (vertices);
			}
		}
		createBuildings ();
	}

	void createBuildings() {
		for (int i = 0; i < buildingVertices.Count; i++) {
			GameObject thisBuilding = new GameObject ();
			thisBuilding.AddComponent<MeshFilter>();
			thisBuilding.AddComponent<MeshRenderer>();
			Mesh mesh = new Mesh (); 
			mesh.Clear();

			Vector3[] vertices = buildingVertices [i].ToArray();
			mesh.vertices = vertices;
			Vector2[] uvs = new Vector2[vertices.Length];
			for (int j = 0; j < uvs.Length; j++)
			{
				uvs[j] = new Vector2(vertices[j].x, vertices[j].z);
			}
			mesh.uv = uvs;

			int mult3 = nearestMultipleOfThree (vertices.Length);
			int[] triangles = new int[mult3];
			for (int j = 0; j < triangles.Length; j++) {
				if (j <= vertices.Length) {
					triangles [j] = j;
				} else {
					triangles[j] = vertices.Length - j;
				}
			}
			mesh.triangles = triangles;
			thisBuilding.GetComponent<MeshFilter>().mesh = mesh;
		}
	}

	int nearestMultipleOfThree(int input) {
		if ((input + 1) % 3 == 0) {
			return input + 1;
		} else if ((input + 2) % 3 == 0) {
			return input + 2;
		} else {
			return input;
		}
	}
}
