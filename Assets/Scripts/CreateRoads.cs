using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;

public class CreateRoads : MonoBehaviour {

	private float min_lon;
	private float min_lat;
	private float max_lon;
	private float max_lat;
	private float boxWidth;
	private float boxHeight;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	// Receive the JSON results from the Mapzen download
	public void ReceiveDownloadResults(string results) {
		var json = JSON.Parse (results);
		JSONArray roadFeatures = json ["roads"] ["features"].AsArray;
		for (int i = 0; i < roadFeatures.Count; i++) {
			var coordinates = roadFeatures [i] ["geometry"]["coordinates"];
			Debug.Log (coordinates);

		}
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
	// Using the spherical law of cosines approximation
	// d = acos( sin lat1 * sin lat2 + cos lat1 * lat φ2 * cos deltaLong ) * R
	// http://www.movable-type.co.uk/scripts/latlong.html
	float distanceBetweenTwoPoints (float lat1, float lon1, float lat2, float lon2)
	{
		// Radius of earth in units of meters, to give meters as units of answer
		float radius = 6371e3f;	
		float deltaLong = toRadians (lon2) - toRadians (lon1);
		float lat1Rad = toRadians (lat1);
		float lat2Rad = toRadians (lat2);
		float distance = Mathf.Acos (Mathf.Sin (lat1Rad) * Mathf.Sin (lat2Rad) + Mathf.Cos (lat1Rad) * Mathf.Cos (lat2Rad) * Mathf.Cos (deltaLong)) * radius;
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
		return degrees * Mathf.PI / 180;
	}


}
