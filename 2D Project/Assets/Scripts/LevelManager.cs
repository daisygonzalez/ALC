using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
public GameObject currentCheckPoint;
    private Rigidbody2D PC;
  
    // Particles
    public GameObject deathParticles;
    public GameObject respawnParticle;
   
    //Respawn Delay
	public float respawnDelay;
    
    
    //Point Penalty on Death
    public int pointPenaltyOnDeath;
    
    // Store Gravity Value
    private float gravityStore;
    
    // Use this for initialization
    
    
	void Start () {
		PC = FindObjectOfType<Rigidbody2D> ();
	}
	
	public void RespawnPlayer(){
        StartCoroutine ("RespawnPlayerCo");
    }
	public IEnumerator RespawnPlayerCo(){
        //Generate Death Particle
        Instantiate (deathParticle, PC,transform.position, PCtrannsform.rotation);
            //Hide PC
            PC,enabled = false;
        PC.GetComponent<Renders> ().enabled = false;
        // Gravity Reset 
        gravityStore = PC.GetCOmponent<Rigidbody2D>().gravityScales;
        PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
        PC.GetComponent<Rigidbody>().velocity = Vector2.zero;
        // Point Penalty
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        //Debug Message
        Debug.Log ("Player Respawn");
        //Respawn Delay
        yield return new WaitForSeconds (respawnDelay);
        //Gravity Restore
        PC.GetComponent<Rigidbody>()gravityScale = gravityStore;
        //Match Plaer transform position
        PC,transform.position = currentCheckPoint.transform.position;
    }
		
	}

