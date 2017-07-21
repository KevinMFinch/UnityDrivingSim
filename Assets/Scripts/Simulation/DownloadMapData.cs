using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DownloadMapData : MonoBehaviour
{

	private int minXTile;
	// Minimum x tile for mapzen data scheme
	private int maxXTile;
	// Maximum x tile for mapzen data scheme
	private int minYTile;
	// Minimum y tile for mapzen data scheme
	private int maxYTile;
	// Maximum y tile for mapzen data scheme
	private int zoomLevel = 16;
	// Zoom level for downloading mapzen data
	// Higher numbers = smaller region, more details
	private string API_KEY = "mapzen-LKAwJUj";
	// API key for mapzen

	public GameObject roadCreator;
	// The object which has the create roads scripts attached to it

	public GameObject cacheHandler;
	// The object which handles caching/loading of tile data

	public GameObject buildingCreator;

	// Use this for initialization
	void Start ()
	{

		// Princeton area
		float minLon = -74.65986f;
		float minLat = 40.34759f;
		float maxLon = -74.64559f;
		float maxLat = 40.35430f;

		minXTile = xFromLon (minLon);
		maxXTile = xFromLon (maxLon);
		minYTile = yFromlat (minLat);
		maxYTile = yFromlat (maxLat);
		Constants.storeBoundingBox (minLon, minLat, maxLon, maxLat);
		StartCoroutine (downloadMapData ());
	}

	IEnumerator downloadMapData() {
		int minx = Mathf.Min (minXTile, maxXTile);
		int maxx = Mathf.Max (minXTile, maxXTile);
		int miny = Mathf.Min (minYTile, maxYTile);
		int maxy = Mathf.Max (minYTile, maxYTile);
		for (int x = minx; x <= maxx; x++) {
			for (int y = miny; y <= maxy; y++) {
				// Caching
				bool fileExists = cacheHandler.GetComponent<CacheTileData> ().CheckForFile(x, y, zoomLevel);
				string results = "";
				if (!fileExists) {
					string url = baseURL () + query (x, y);
					WWW www = new WWW (url);
					yield return www;
					results = www.text;
					cacheHandler.GetComponent<CacheTileData> ().SaveFile (x, y, zoomLevel, results);
				} else {
					results = cacheHandler.GetComponent<CacheTileData> ().LoadFile (x, y, zoomLevel);
					yield return results;
				}
				roadCreator.GetComponent<CreateRoads> ().ReceiveDownloadResults (results);
				roadCreator.GetComponent<CreateRoads> ().finishBuilding ();
				buildingCreator.GetComponent<CreateBuildings> ().receiveData (results);
			}
		}
		Debug.Log ("all done downloading"); 




	}

	// Returns the base URL for the mapzen vector tile sercvice
	string baseURL() {
		return "https://tile.mapzen.com/mapzen/vector/v1/all/";
	}

	// Return the query portion of the url
	// In form of /zoom/xtile/ytile.json?api_key=mapzen_api_key
	string query(int x, int y) {
		return zoomLevel + "/" + x + "/" + y + ".json?api_key=" + API_KEY;
	}

	// Calculate the x tile based on a longitude
	// https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames
	int xFromLon (float lon)
	{
		int n = (int)Mathf.Pow (2, zoomLevel);
		int tile = (int)((lon + 180) / 360 * n);
		return tile;
	}

	// Calculate the y tile based on a latitude
	// https://wiki.openstreetmap.org/wiki/Slippy_map_tilenames
	int yFromlat (float lat_degrees)
	{
		float lat_rad = Calc.toRadians (lat_degrees);
		int n = (int)Mathf.Pow (2, zoomLevel);
		int tile = (int)(((1.0 - (Mathf.Log (Mathf.Tan (lat_rad) + 1 / Mathf.Cos (lat_rad))) / Mathf.PI) / 2.0 * n));
		return tile;
	}

	// Update is called once per frame
	void Update ()
	{

	}
}