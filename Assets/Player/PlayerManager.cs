using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.Animations;
public class PlayerManager : MonoBehaviour {
    NavMeshAgent agent;
	int points ;
    [SerializeField] Text healtPts;
	[SerializeField]int maxHealth=3;
	int health;
	Rigidbody _rigidBody;
	[SerializeField] Vector3 target;

	[SerializeField] int laserDmg=1;

    [SerializeField] int healthPts=1;

    
	mainManager mainManager;


   void Awake(){
	   
   }
	// Use this for initialization
	void Start () {
		maxHealth=3;
		health = maxHealth;
		mainManager = Camera.main.GetComponent<mainManager>();
	    _rigidBody=gameObject.GetComponent<Rigidbody>();
		points =0;
	    updateText();
		 agent = GetComponent<NavMeshAgent>();
		 	Debug.Log(agent);
			 Debug.Log("agent");
		
		 
	}
	
	// Update is called once per frame
	void Update () {
	    deathChecker();
		 if (Input.GetMouseButton(0)){ 
     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
     RaycastHit hit;
     if (Physics.Raycast(ray, out hit)){
		  Debug.Log(hit.point);
		 Vector3 currPosition = transform.position;
		 Vector3 clickedPos = hit.point;
		 agent.SetDestination(clickedPos);
		
   }
	}
}


public void OnTriggerEnter(Collider other){

    if(other.gameObject.tag == "point"){
           onAddPoint(other);
	  }
	    if(other.gameObject.tag == "laser"){
		    health = health-laserDmg;
	  }

	   if(other.gameObject.tag == "Health"){
			Destroy(other.gameObject);
			 
	  }

	  if(other.gameObject.tag == "Power"){
			Destroy(other.gameObject);
			onAddPower();
			 
	  }

	  updateText();
}

	public void OnCollisionEnter(Collision other)
	{
		 if(other.gameObject.tag == "danger"){
           health = health-1;
		   
		 //  _rigidBody.AddForce(new Vector3(5f,0,0),ForceMode.Impulse);
	  }
	  if(other.gameObject.tag == "death"){
        health=0;
	  }

	   if(other.gameObject.tag == "Condor"){
        health=health-1;
	  }


	  updateText();
	}

    public void onAddPower(){
			mainManager.playerAddPower();
	}

 	public void onAddPoint(Collider other){
     		points++;
			agent.speed = agent.speed+0.4f;
			Destroy(other.gameObject);
			mainManager.spawningRate=-0.2f;
			updateText();
			mainManager.spawnPoint();
			mainManager.increaseFollowersSpeed();
			mainManager.numberOfMobs=mainManager.numberOfMobs+0.1f;
 		}

	 void updateText(){
		 Debug.Log(health);
       	healtPts.text = "Hp/maxHp:"+health+"/"+maxHealth+"/"+"points:"+points;
	 }


	 void deathChecker(){
		 if(health<=0){
            Destroy(this.gameObject);
		 }

	 }


     }



