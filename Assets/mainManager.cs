using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mainManager : MonoBehaviour {
    [SerializeField] GameObject point;
	[SerializeField] GameObject danger;

	[SerializeField] GameObject terrian;
	[SerializeField] GameObject monster;

	[SerializeField] GameObject tree;
	private GameObject laser;

	public float numberOfMobs;
    

	public float spawningRate;

	void Start () {
		numberOfMobs=1f;
		spawningRate = 5;
		InvokeRepeating("SpawnMonster", 5, spawningRate);
			for(int i=0;i<20;i++){
			spawnPoint();
		  Vector3 position2 = new Vector3(Random.Range(-45, 45), 0.15f, Random.Range(-45, 45));
          Instantiate(danger,position2,Quaternion.identity );
		   Vector3 treePos = new Vector3(Random.Range(-45, 45), -0.30f, Random.Range(-45, 45));
          Instantiate(tree,treePos,Quaternion.identity );
	
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void SpawnMonster(){
		if(GameObject.Find ("Danger_1(Clone)") != null){
            Destroy(GameObject.Find ("Danger_1(Clone)"));
		}
		float tempNimbOfMobs = numberOfMobs;
		for(int i=0;i<1;i++){
			Debug.Log("wa7ed "+tempNimbOfMobs);
		 Vector3 position2 = new Vector3(Random.Range(-45, 45), 2.703f, Random.Range(-45, 45));
		 Vector3 rotation = new Vector3(0, Random.Range(0, 360), 0);
		 Instantiate(monster,position2,Quaternion.Euler(rotation) );
		}
	}

	void visibleMonsterLaser(){
       laser.SetActive(true);
	}

	public void spawnPoint(){
		 Vector3 position = new Vector3(Random.Range(-45, 45), 1f, Random.Range(-45, 45));
          Instantiate(point,position,Quaternion.identity );
	}
}
