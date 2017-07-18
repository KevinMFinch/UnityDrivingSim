using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Contains various calculation functions that are used throughout the project

public class Calc {

	// helper method to get radians from degrees
	public static float toRadians(float degrees) {
		return degrees * Mathf.PI / 180;
	}

	// Returns the distance between two latitudes and longitudes, in meters.
	// Using the haversine formula
	// http://andrew.hedges.name/experiments/haversine/
	public static float distanceBetweenTwoPoints (float lat1, float lon1, float lat2, float lon2)
	{
		float radius = 6371e3f;	// This is the radius of the earth, in meters. Gives distance in meters
		float dlon = toRadians (lon2) - toRadians (lon1);
		float dlat = toRadians (lat2) - toRadians (lat1);
		float a = Mathf.Pow (Mathf.Sin (dlat / 2), 2);
		a += Mathf.Cos (toRadians (lat1)) * Mathf.Cos (toRadians (lat2)) * Mathf.Pow (Mathf.Sin (dlon / 2), 2);
		float c = 2 * Mathf.Atan2 (Mathf.Sqrt (a), Mathf.Sqrt (1 - a));
		float distance = radius * c;
		return distance;
	}

	// Calculate the Unity z coordinate from a longitude
	// Uses the bottom left of the bounding box as the origin of the coordinate system
	// AKA, a point at (minLong, minLat) would have a Unity position of (0, 0, 0)
	// A point at (maxLong, minlat) would have a Unity position of (0, 0, Z) where Z is what is being
	// Calculated in this function
	public static float longToZCoord (float longitude)
	{
		float distance = distanceBetweenTwoPoints (Constants.min_lat, Constants.min_lon, Constants.min_lat, longitude);
		if (longitude < Constants.min_lon) {
			distance *= -1;
		}
		return distance;
	}

	// Calculate the Unity x coordinate from a latitude
	// Same coordinate system as the one for longToZCoord
	public static float latToXCoord (float latitude)
	{
		float distance = distanceBetweenTwoPoints (Constants.min_lat, Constants.min_lon, latitude, Constants.min_lon);
		if (latitude < Constants.min_lat) {
			distance *= -1;
		}
		return distance;
	}

}