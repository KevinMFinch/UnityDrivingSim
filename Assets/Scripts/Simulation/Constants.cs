using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Constants {

	public static float min_lon;
	// Min lon of the bounding box
	public static float min_lat;
	// Min lat of the bounding box
	public static float max_lon;
	// Max lon of the bounding box
	public static float max_lat;
	// Max lat of the bounding box
	public static float boxWidth;
	// Height of the bounding box in meters
	public static float boxHeight;
	// Width of the bounding box in meters

	// Receive and store the bounding box of the openstreetmap query for use in calculating distances for rendering roads
	// Also calculate height and width of bounding box, in meters
	public static void storeBoundingBox (float min_long, float min_lati, float max_long, float max_lati)
	{
		min_lon = min_long;
		min_lat = min_lati;
		max_lon = max_long;
		max_lat = max_lati;
		calculateWidthAndHeightOfBBox ();
	}

	// Calculate and store width and height of bounding box
	public static void calculateWidthAndHeightOfBBox ()
	{ 
		boxWidth = Calc.distanceBetweenTwoPoints (min_lat, min_lon, min_lat, max_lon);
		boxHeight = Calc.distanceBetweenTwoPoints (max_lat, min_lon, min_lat, min_lon);
		Terrain t = Terrain.activeTerrain;
		t.terrainData.size = new Vector3 (2 * boxHeight, 1, 2 * boxWidth);
		t.transform.position = new Vector3 (-boxHeight / 2, 0, -boxWidth / 2);
		t.drawTreesAndFoliage = true;
	}
}
