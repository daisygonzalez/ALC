using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {
public GameObject CurrentCheckPoint;
    public Rigidbody2D PC;
  
  public GameObject PC2;

    // Particles
    public GameObject DeathParticle;
    public GameObject RespawnParticle;
   
    //Respawn Delay
	public float respawnDelay;
    
    
    //Point Penalty on Death
    public int pointPenaltyOnDeath;
    
    // Store Gravity Value
    private float gravityStore;
    
    // Use this for initialization
    
    
	void Start () {
		    PC = GameObject.Find("PC").GetComponent<Rigidbody2D>();
        PC2 = GameObject.Find("PC");
	}
	
	
	public void RespawnPlayer(){
        StartCoroutine ("RespawnPlayerCo");
    }
	public IEnumerator RespawnPlayerCo(){
        //Generate Death Particle
        Instantiate (DeathParticle, PC.transform.position, PC.transform.rotation);
            //Hide PC
            // PC.enable= false;
        PC2.SetActive(false);
        PC.GetComponent<Renderer> ().enabled = false;
        // Gravity Reset 
        gravityStore = PC.GetComponent<Rigidbody2D>().gravityScale;
        PC.GetComponent<Rigidbody2D>().gravityScale = 0f;
        PC.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        // Point Penalty
        ScoreManager.AddPoints(-pointPenaltyOnDeath);
        //Debug Message
        Debug.Log ("PC Respawn");
        //Respawn Delay
        yield return new WaitForSeconds (respawnDelay);
        //Gravity Restore
        PC.GetComponent<Rigidbody2D>().gravityScale = gravityStore;
        //Match PCs transform position
        PC.transform.position = CurrentCheckPoint.transform.position;
        PC2.SetActive(true);
   //Show Pc
        //Pc.enabled = true;
        PC.GetComponent<Renderer> ().enabled = true;
    //Spawn PC
    Instantiate (RespawnParticle, CurrentCheckPoint.transform.position, CurrentCheckPoint.transform.rotation);
    }
		
	}

