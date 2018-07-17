using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
public class Mov_test : MonoBehaviour {
    NavMeshAgent agent;
	int points ;
    [SerializeField] Text healtPts;
	[SerializeField]int maxHealth=100;
	int health;
	Rigidbody _rigidBody;
	[SerializeField] Vector3 target;

	[SerializeField] int laserDmg=20;

	mainManager mainManager;

   void Awake(){
	   
   }
	// Use this for initialization
	void Start () {
		maxHealth=100;
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
	
		 if (Input.GetMouseButtonDown(0)){ 
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



	void OnTriggerEnter(Collider other)
	{

	  if(other.gameObject.tag == "point"){
           onAddPoint(other);
		   Debug.Log(points);
	  }
	    if(other.gameObject.tag == "laser"){
		    health = health-laserDmg;
	  }
	}

		void OnCollisionEnter(Collision other)
	{
		 if(other.gameObject.tag == "danger"){
           health = health-10;
		   updateText();
		   _rigidBody.AddForce(new Vector3(20f,0,0),ForceMode.Impulse);
	  }
	  if(other.gameObject.tag == "death"){
        health=0;
		updateText();
	  }
	}


 	public void onAddPoint(Collider other){
     		points++;
			agent.speed = agent.speed+0.4f;
			Destroy(other.gameObject);
			mainManager.spawningRate=-0.2f;
			transform.localScale += new Vector3(0, 0, 1f);
			updateText();
			mainManager.spawnPoint();
			//mainManager.numberOfMobs +=0.1f;
 		}

	 void updateText(){
		 Debug.Log(health);
       	healtPts.text = "health/maxHealth:"+health+"/"+maxHealth+"////"+"points:"+points;
	 }


     }



