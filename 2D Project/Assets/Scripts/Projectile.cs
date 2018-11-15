using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {
public float Speed;
    public GameObject PC;
public float TimeOut;
    public GameObject EnemyDeath;
    public GameObject ProjectileParticle;
    public int PointsForKill;
	// Use this for initialization
	void Start () {
	PC = GameObject.Find("PC");
    EnemyDeath = Resources.Load("Prefabs/DeathP") as GameObject;
    ProjectileParticle = Resources.Load("Prefabs/Particle System") as GameObject;
    	if(PC.transform.localScale.x < 0) 
            Speed = -Speed;
	}
	// Destory Projectile after X seconds
     //Destroy(GameObject,TimeOut);

	// Update is called once per frame
	void Update () {
		 GetComponent<Rigidbody2D>().velocity = new Vector2(Speed, GetComponent<Rigidbody2D>().velocity.y);
        if(PC.transform.localScale.x < 0)
            Speed = -Speed;
	}
   
    void OnTriggerEnter2D(Collider2D other){
        //Destroys enemy on contact with projectile. Adds points.
        if(other.tag == "Enemy"){
            Instantiate(EnemyDeath, other.transform.position, other.transform.rotation);
                Destroy (other.gameObject);
            ScoreManager.AddPoints (PointsForKill);
        }
        Instantiate(ProjectileParticle, transform.position, transform.rotation);
        Destroy (gameObject);
        
    } void OnCollistionEnter2D(Collision2D other) {}
}
