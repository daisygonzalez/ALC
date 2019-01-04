using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class Charactermove : MonoBehaviour
{

    //Player Movement Variables
    public int MoveSpeed;
    public float Jumpheight;
    private bool doubleJump;

    //Player grounded variables
    public Transform groundcheck;
    public float groundCheckRadius;
    public LayerMask whatIsGround;
    private bool grounded;

    //Non-Slide Player
  public float moveVelocity;
    //Use this for initialization
    void Start()
    {
        
    }


    void FixedUpdate ()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position, groundCheckRadius, whatIsGround);
    }

    //Update Is called once per frame
    void Update()
    {

        // This code makes the charcter jump
        if (Input.GetKeyDown (KeyCode.Space)&& grounded)
        {
            Jump();
        }
        // Double jump code
        if (grounded){
            doubleJump = false;}
        if (Input.GetKeyDown(KeyCode.Space)&& !doubleJump && !grounded)
        {
            Jump();
            doubleJump = true;
        }
        //Non-Slide Player 
        moveVelocity = 0f;

        //  This code makes the character move from side to side using the A&D keys
        if (Input.GetKey (KeyCode.D)){
            //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        moveVelocity = MoveSpeed;}
        
        if (Input.GetKey (KeyCode.A))
        {
            //GetComponent<Rigidbody2D>().velocity = new Vector2(MoveSpeed, GetComponent<Rigidbody2D>().velocity.y);
        moveVelocity = -MoveSpeed;}

        GetComponent<Rigidbody2D>().velocity = new Vector2(moveVelocity, GetComponent<Rigidbody2D>().velocity.y);
         //Player flip
         if (GetComponent<Rigidbody2D>().velocity.x > 0)
            transform.localScale = new Vector3(5f,5f,1f);

         else if (GetComponent<Rigidbody2D>().velocity.x < 0){
            transform.localScale = new Vector3(-5f,5f,1f);
        }

    }

    public void Jump()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, Jumpheight);
    }
}




