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
				float height = Random.Range (5, 15);
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

			List<int> tris = new List<int> ();
			// Convert vertices to array for mesh
			Vector3[] vertices = buildingVertices [i].ToArray();

			// Do the triangles for the roof and the floor of the building
			// Roof points are at odd indeces
			for (int j = vertices.Length - 3; j >= 0; j--) {
				// Add the point
				tris.Add (j);
				// Check for wrap around
				if (j - 2 >= 0) {
					tris.Add (j - 2);
				} else {
					// If wrap around, add the first vertex
					int diff = j - 2;
					tris.Add (vertices.Length - 2 + diff);
				}
				// Check if its at ground or building height level, choose proper center point
				if (j % 2 == 0) {
					tris.Add (vertices.Length - 2);
				} else {
					tris.Add (vertices.Length - 1);
				}
			}

			// Do triangles which connect roof to ground
			for (int j = vertices.Length-3; j >= 2; j--){ 
				if (j % 2 == 1) {
					tris.Add (j);
					tris.Add (j - 1);
					tris.Add (j - 2);
				} else {
					tris.Add (j);
					tris.Add (j - 2);
					tris.Add (j - 1);
				}
			}

			Vector2[] uvs = new Vector2[vertices.Length];
			for (int j = 0; j < uvs.Length; j++) {
				uvs[j] = new Vector2(vertices[j].x, vertices[j].z);
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
			mesh.uv = uvs;
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
		return center / (verts.Count / 2);

	}

}
