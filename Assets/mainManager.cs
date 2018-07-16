using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainManager : MonoBehaviour {
    [SerializeField] GameObject point;
	[SerializeField] GameObject danger;

	[SerializeField] GameObject terrian;
	// Use this for initialization
	void Start () {
			for(int i=0;i<20;i++){
			 Vector3 position = new Vector3(Random.Range(-45, 45), 0.15f, Random.Range(-45, 45));
          Instantiate(point,position,Quaternion.identity );
		  Vector3 position2 = new Vector3(Random.Range(-45, 45), 0.15f, Random.Range(-45, 45));
          Instantiate(danger,position2,Quaternion.identity );
		   //Vector3 position3 = new Vector3(Random.Range(-45, 45), 0, Random.Range(-45, 45));
       //   Instantiate(terrian,position3,Quaternion.identity );
		}
	}
	
	// Update is called once per frame
	void Update () {
	 
		
	}
}
