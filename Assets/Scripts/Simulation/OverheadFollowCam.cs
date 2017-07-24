using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverheadFollowCam : MonoBehaviour {

	public GameObject player;
	// The player game object
	private Vector3 offset;
	// The offset between the camera and the player, keeps relative position constant

	void Start ()
	{
		offset = transform.position - player.transform.position;
	}

	void LateUpdate ()
	{
		transform.position = player.transform.position + offset;
	}
}
