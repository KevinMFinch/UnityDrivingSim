using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;


// Caches JSON files from Mapzen to reduce both loading time and Mapzen server load
// Handles loadin and saving of data to disk
// Saves files in the format x_y_zoom.json in the "Tiles" directory
public class CacheTileData : MonoBehaviour {

	private string basePath = "C:\\Users\\kfinch\\Desktop\\TileData";
	// Use this for initialization
	void Start () {
		
	}

	// Check for the particular tile and zoom combination json file
	public bool CheckForFile(int x, int y, int zoom) {
		string fileName = x + "_" + y + "_" + zoom + ".txt";
		string filePath = Path.Combine (basePath, fileName);
		if (File.Exists (filePath)) {
			return true;
		} else {
			return false;
		}
	}

	public void SaveFile(int x, int y, int zoom, string text) {
		string fileName = x + "_" + y + "_" + zoom + ".txt";
		string filePath = Path.Combine (basePath, fileName);
		File.WriteAllText (filePath, text);
		Debug.Log ("File saved");

		#if UNITY_EDITOR
		UnityEditor.AssetDatabase.Refresh();
		#endif
	}

	// Guaranteed to return something since CheckForFile will always be called first
	// If the file does not exist, LoadFile() will not be called
	public string LoadFile(int x, int y, int zoom) {
		Debug.Log ("Load file");
		string fileName = x + "_" + y + "_" + zoom + ".txt";
		string filePath = Path.Combine (basePath, fileName);
		string contents = File.ReadAllText (filePath);
		Debug.Log ("CONTENTS: ");
		Debug.Log (contents);
		return contents;
	}

}
