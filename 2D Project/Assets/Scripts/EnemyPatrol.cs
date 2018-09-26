﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour {

    // Movemenet Variables
    public float Movespeed;
    public bool MoveRight;
      // Wall CHeck
     public Transform WallCheck;
    public float WallCheckRadius;
     public LayerMask WhatIsWall;
    private bool HittingWall;
    // Edge Check
     private bool NotAtEdge;
     public Transform EdgeCheck;

   	
	}

// Update is called once per frame
void Update (){
    NotAtEdge = Physics2D.OverlapCircle(EdgeCheck.position, WallCheckRadius, WhatIsWall);

    HittingWall = Physics2D.OverlapCircle(WallCheck.position, WallCheckRadius, WhatIsWall);

    if (HittingWall || !NotAtEdge){
        MoveRight = !MoveRight;
        
    }
    if (MoveRight)
    {
        Transform.localScale = new Vector3(-1f, 1f, 1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(Movespeed, GetComponent<Rigidbody2D>().velocity.y);


    }
    else
    {
        Transform.localScale = new Vector3(1f,1f,1f);
        GetComponent<Rigidbody2D>().velocity = new Vector2(-Movespeed, GetComponent<Rigidbody2D>().velocity.y);
    }//ends else

  }//ends update
}//ends class
