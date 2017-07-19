using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class CreateBuildings : MonoBehaviour {

	// A list of lists of vertices that make up each building
	List<float> buildingHeights = new List<float>();

	public Material mat;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Receive the GeoJSON data from Mapzen, parse for buildings
	public void receiveData(string results) {
		var json = JSON.Parse (results);
		List<List<Vector3>> buildingVertices = new List<List<Vector3>> ();
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
		createBuildings (buildingVertices);
	}

	void createBuildings(List<List<Vector3>> buildingVertices) {
		Debug.Log (buildingVertices.Count);
		for (int i = 0; i < buildingVertices.Count; i++) {
			// Create a building game object
			GameObject thisBuilding = new GameObject ("Building "+ i);
			float height = buildingVertices [i] [1].y;
			// Compute the center point of the polygon both on the ground, and at height
			// Add center vertices to end of list
			Vector3 center = findCenter (buildingVertices[i]);
			buildingVertices[i].Add (center);
			Vector3 raisedCenter = center;
			raisedCenter.y += height;
			buildingVertices[i].Add (raisedCenter);

			/******
			 * Use a list for the triangles since I dont really know how many there
			 * are going to be for each building. Generate triangles in the same way as before,
			 * just add them to list and then convert list to array at the end
			 * 
			 ****/
			List<int> tris = new List<int> ();
			// Convert vertices to array for mesh
			Vector3[] vertices = buildingVertices [i].ToArray();
			// Populate triangles array with triangles that are two outside vertices and the center vertex for the y level
			for (int j = 0; j < vertices.Length-2; j++) {
				tris.Add(j);
				tris.Add(j + 2);
				// The center vertex is on the ground if it is in the even indeces
				if (j % 2 == 0) {
					tris.Add(vertices.Length - 2);
				} else {
					tris.Add(vertices.Length - 1);
				}

				tris.Add (j);
				tris.Add (j + 1);
				tris.Add (j + 2);
			}
				


			int[] triangles = tris.ToArray();

			// Create and apply the mesh
			MeshFilter mf = thisBuilding.AddComponent<MeshFilter>();
			Mesh mesh = new Mesh();
			mf.mesh = mesh;
			Renderer rend = thisBuilding.AddComponent<MeshRenderer>();
			rend.material = mat;
			mesh.vertices = vertices;
			mesh.triangles = triangles;
			mesh.RecalculateBounds();
			mesh.RecalculateNormals();

		}
	}

	// Find the center X-Z position of the polygon.
	Vector3 findCenter(List<Vector3> verts) {
		Vector3 center = Vector3.zero;
		// Only need to check every other spot since the odd indexed vertices are in the air, but have same XZ as previous
		for (int i = 0; i < verts.Count; i+= 2) {
			center += verts [i];
		}
		center.y = 0;
		return center / (verts.Count / 2);

	}

}
