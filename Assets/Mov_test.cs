using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Mov_test : MonoBehaviour {
    NavMeshAgent agent;
	int points ;
	Rigidbody _rigidBody;
	[SerializeField] Vector3 target;

	// Use this for initialization
	void Start () {
	    _rigidBody=gameObject.GetComponent<Rigidbody>();
		points =0;
		 agent = GetComponent<NavMeshAgent>();
		
		 
	}
	
	// Update is called once per frame
	void Update () {
		// RotateTowards(target);
		//	transform.Rotate(90,0,0);
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
			Debug.Log(other.gameObject.tag);
	  if(other.gameObject.tag == "point"){
            points++;
			agent.speed = agent.speed+0.1f;
			Destroy(other.gameObject);
	  }
	}

    private void RotateTowards(Vector3 target)
 {
     Vector3 direction = (target - transform.position).normalized;
	 var qTo = Quaternion.LookRotation(direction);
       qTo = Quaternion.Slerp(transform.rotation, qTo, 30.0f * Time.deltaTime);
         _rigidBody.MoveRotation(qTo);
 }


     }



