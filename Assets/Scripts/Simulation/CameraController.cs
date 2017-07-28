using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

	public GameObject player;
	// The player game object
	private Camera camera;
	// This camera
	private Vector3 offset;
	// The offset between the camera and the player, keeps relative position constant

	void Start ()
	{
		camera = GetComponent<Camera> ();
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.rotation = player.transform.rotation;
		transform.position = player.transform.position + offset;
	}

	/* void OnGUI()
	{
		Vector3 p = new Vector3();
		Camera  c = Camera.main;
		Event   e = Event.current;
		Vector2 mousePos = new Vector2();

		// Get the mouse position from Event.
		// Note that the y position from Event is inverted.
		mousePos.x = e.mousePosition.x;
		mousePos.y = c.pixelHeight - e.mousePosition.y;

		p = c.ScreenToWorldPoint(new Vector3(mousePos.x, mousePos.y, c.nearClipPlane));

		GUILayout.BeginArea(new Rect(20, 20, 250, 120));
		GUILayout.Label("Screen pixels: " + c.pixelWidth + ":" + c.pixelHeight);
		GUILayout.Label("Mouse position: " + mousePos);
		GUILayout.Label("World position: " + p.ToString("F3"));
		GUILayout.EndArea();
	} */


}