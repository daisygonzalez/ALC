using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Charactermove : MonoBehaviour
{

    //Player Movement Variables
    public int MoveSpeed;
    public float Jumpheight;

    //Player grounded variables
    public Transform groundcheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    //Use this for initialization
    void Start()
    {

    }


    void FixUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);
    }

    //Update Is called once per frame
    void Update()
    {

        // This code makes the charcter jump
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Jump();
        }

        //  This code makes the character move from side to side using the A&D keys
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        }

    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jumpheight);
    }
}



