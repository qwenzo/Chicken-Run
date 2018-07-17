using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterManager : MonoBehaviour {
   private GameObject laser;
	// Use this for initialization
	void Start () {
		Vector3 rotation = new Vector3(0, Random.Range(0, 360), 0);
		 transform.rotation = Quaternion.Euler(rotation);
		 laser = transform.GetChild (0).gameObject;
		  Invoke("visibleMonsterLaser",1.5f);
		  
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void visibleMonsterLaser(){
       laser.SetActive(true);
	}

	
	 
	}

	

