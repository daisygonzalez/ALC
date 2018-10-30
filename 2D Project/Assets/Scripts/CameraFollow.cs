using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
public Charactermove Player;
public bool isfollowing;
// Camera position offset;
public float xoffset;
public float yoffset;

	// Use this for initialization
	void Start () {
		Player = FindObjectOfType<Charactermove>();
		isfollowing = true;
	}
	
	// Update is called once per frame
	void Update () {
		if(isfollowing)
			transform.position = new Vector3(Player.transform.position.x + xoffset, Player.transform.position.y + xoffset, transform.position.z);
		
				}
}
