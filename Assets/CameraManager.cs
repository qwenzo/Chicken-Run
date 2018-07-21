using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {
    Vector3 distance ;
	// Use this for initialization
	void Start () {
		Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
	   distance = transform.position-playerPos;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		transform.position= GameObject.FindGameObjectWithTag("Player").transform.position+distance;
		
	}
}
