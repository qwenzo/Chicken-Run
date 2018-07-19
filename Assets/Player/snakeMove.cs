using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class snakeMove : MonoBehaviour {
  //  private string move;
	// private string secondMove;
	// Use this for initialization
	NavMeshAgent agent;
	void Start () {
	//	move = "forward";
	//	secondMove = "";
	   agent = GetComponent<NavMeshAgent>();
		
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
		 agent.Move(clickedPos);
		
   }
		/* 
			if(secondMove == ""){
		switch(move){
         case "back":transform.Translate(0,0,0.5f);break;
		 case "forward":transform.Translate(0,0,-0.5f);break;
		 default:transform.Translate(0,0,-0.5f);break;
		}
		}
		switch(secondMove){
         case "left":if(move=="forward"){
			 transform.Translate(0.5f,0,-0.5f);
			 } else {
				 transform.Translate(0.5f,0,0.5f);
				 };break;
		 case "right":if(move=="forward"){
			 transform.Translate(-0.5f,0,-0.5f);
			 } else {
				 transform.Translate(-0.5f,0,0.5f);
				 };break;
		 default:transform.Translate(0,0,-0.5f);break;
		}
		 if (Input.GetMouseButtonDown(0)){ 
     Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
     RaycastHit hit;
     if (Physics.Raycast(ray, out hit)){
		  Debug.Log(hit.point);
		 Vector3 currPosition = transform.position;
		 Vector3 clickedPos = hit.point;
		 if(clickedPos.z > transform.position.z){
            move = "back";
			SecondMove(clickedPos);
			
		 }
		 else if(clickedPos.z < transform.position.z){
               move = "forward";
			    SecondMove(clickedPos);
		 }

		
   }
	}
		
		*/
	
}

/* 
void SecondMove(Vector3 clickedPos){
     if(clickedPos.x > transform.position.x){
               secondMove = "left";
		 }

		 else if(clickedPos.x < transform.position.x){
               secondMove = "right";
		 }
}

*/

}
}
