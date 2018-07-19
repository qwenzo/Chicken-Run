using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class followerMov : MonoBehaviour {
	 [SerializeField]GameObject chicken;
    NavMeshAgent agent;
	[SerializeField] float agentspeed;

	public bool isControlled;
	// Use this for initialization
	void Start () {
		isControlled = false;
		agentspeed=Random.Range(10, 5);
		 agent = GetComponent<NavMeshAgent>();
		 agent.speed=agentspeed;
		 chicken = GameObject.FindGameObjectWithTag("Player");
	}
	
	void FixedUpdate()
	{
		if(agent.gameObject!=null && !isControlled)
		agent.SetDestination(chicken.transform.position);
	
	}
	
	void OnCollisionEnter(Collision other)
	{
	}
}
