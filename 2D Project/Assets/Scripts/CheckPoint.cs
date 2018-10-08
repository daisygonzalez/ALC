﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

	public LevelManager LevelManager;
    // Use this for initialization
	void Start () {
		LevelManager = FindObjectOfType <LevelManager>();
	}
	
	// Update is called once per frame
	void Update () {
	
    }
    
    
    void OnTriggerEnter2D(Collider2D other){
    if(other.name == "PC"){
        LevelManager.CurrentCheckPoint = gameObject;
        Debug.Log("Activated Checkpoint" + transform.position);
    }
    
    
	}
}
