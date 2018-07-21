using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class mainManager : MonoBehaviour {
    [SerializeField] GameObject point;
	[SerializeField] GameObject danger;

	[SerializeField] GameObject terrian;
	[SerializeField] GameObject monster;
	[SerializeField] GameObject tree;
   [SerializeField] int healthCount=5;
   [SerializeField] GameObject follower;
	[SerializeField] GameObject health;
   [SerializeField] GameObject power;
	[SerializeField] int noOfFollowers;
	private GameObject laser;
	[SerializeField] public float numberOfMobs;
	public float spawningRate;

	private MonsterManager monsterManager;

	private MonsterManager BossmonsterManager;

	private Vector3 MoboldScale;

	void Start () {
		numberOfMobs=20f;
		spawningRate = 5;
		InvokeRepeating("BossMonster", 0, 10f);
		InvokeRepeating("spawnPower", 0, 25f);
		InvokeRepeating("EnargizeMonster", 0, 5f);
		spawnMonster();
		//spawnHealth(healthCount);
			for(int i=0;i<20;i++){
			if(i<noOfFollowers){
				spawnFollower();
			}
			spawnPoint();
			spawnTrees();
			spawnDanger();
	
		}
	}
	
	void FixedUpdate () {
		if(BossmonsterManager!=null && BossmonsterManager.isBoss  && !BossmonsterManager.isControlled){
		 
          BossmonsterManager.transform.Rotate(new Vector3(0,180*Time.deltaTime,0));
		 }
		
		
	}

	void spawnPower(){
		Vector3 Pos = new Vector3(Random.Range(-45, 45), 1.05f, Random.Range(-45, 45));
          Instantiate(power,Pos,Quaternion.Euler(new Vector3(-90,0,0)) );
	}

	void EnargizeMonster(){
		GameObject[] Monsters =GameObject.FindGameObjectsWithTag("Monster");
		int indexOfMob = Random.Range(0, Monsters.Length);
		GameObject monster = Monsters[indexOfMob];
		 monsterManager = monster.GetComponent<MonsterManager>();
		monsterManager.isEnargized = true;
		monsterManager.navMeshAgent.speed = 2000f;
        monsterManager.material.color = Color.red;
		int invokeTime = 5;
		int invokeTmp = invokeTime;
           monsterManager.Move();
		   Invoke("DeEnargize",3f);
		 
		
	}

	void DeEnargize(){
		monsterManager.navMeshAgent.speed = 10f;
		monsterManager.isEnargized = false;
         Color color;
		ColorUtility.TryParseHtmlString ("E6E6E6", out color);
		monsterManager.material.color=color;    
	}


	void BossMonster(){
		GameObject[] Monsters =GameObject.FindGameObjectsWithTag("Monster");
		int indexOfMob = Random.Range(0, Monsters.Length);
		 BossmonsterManager = Monsters[indexOfMob].GetComponent<MonsterManager>();
		 MoboldScale = BossmonsterManager.transform.localScale;
		BossmonsterManager.transform.position = new Vector3(Random.Range(-45, 45), 0, Random.Range(-45, 45));
		BossmonsterManager.transform.localScale+= new Vector3(5F, 5F, 5F);
		  BossmonsterManager.navMeshAgent.enabled = false;
		  BossmonsterManager.isBoss = true;
		  Invoke("DeBossing",5f);
		

	}

	void DeBossing(){
		BossmonsterManager.transform.localScale = MoboldScale;
		BossmonsterManager.navMeshAgent.enabled = true;
		BossmonsterManager.isBoss = false;
	}

	void spawnTrees(){
		Vector3 treePos = new Vector3(Random.Range(-45, 45), -0.30f, Random.Range(-45, 45));
          Instantiate(tree,treePos,Quaternion.identity );

	}

	void spawnDanger(){
		Vector3 position2 = new Vector3(Random.Range(-45, 45), 0.15f, Random.Range(-45, 45));
          Instantiate(danger,position2,Quaternion.identity );
	}


	void spawnMonster(){
		//checkExistsMob();
		float tempNimbOfMobs = numberOfMobs;
		for(float i=0;i<tempNimbOfMobs;i++){
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
          Instantiate(point,position,Quaternion.Euler(new Vector3(-90,0,0)) );
	}

	public void spawnHealth(int count){
			for(int i=0;i<count;i++){
		 Vector3 position = new Vector3(Random.Range(-45, 45), 0.63f, Random.Range(-45, 45));
          Instantiate(health,position,Quaternion.Euler(new Vector3(-90,0,0)) );
			}
	}

	void checkExistsMob(){
		foreach(GameObject mob in GameObject.FindGameObjectsWithTag("Monster")){
             Destroy(mob);
		}

	}

public	void playerAddPower(){
		foreach(GameObject mob in GameObject.FindGameObjectsWithTag("Monster")){
           MonsterManager  monsterManager = mob.GetComponent<MonsterManager>();
			 monsterManager.isControlled = true;
		}
		foreach(GameObject follower in GameObject.FindGameObjectsWithTag("Condor")){
           followerMov  followerMov = follower.GetComponent<followerMov>();
			 followerMov.isControlled = true;
		}

		Invoke("onLosingPower",3f);
	}

	void onLosingPower(){
		foreach(GameObject mob in GameObject.FindGameObjectsWithTag("Monster")){
           MonsterManager  monsterManager = mob.GetComponent<MonsterManager>();
			 monsterManager.isControlled = false;
		}
		foreach(GameObject follower in GameObject.FindGameObjectsWithTag("Condor")){
           followerMov  followerMov = follower.GetComponent<followerMov>();
			 followerMov.isControlled = false;
		}

	}

	public void increaseFollowersSpeed(){
		foreach(GameObject condor in GameObject.FindGameObjectsWithTag("Condor")){
           NavMeshAgent  condorAgent = condor.gameObject.GetComponent<NavMeshAgent>();
		  float followerSpeed= condorAgent.speed;
		  condorAgent.speed =  followerSpeed+Random.Range(0f,0.5f);
		}

	}

	void spawnFollower(){
		Vector3 position2 = new Vector3(Random.Range(-45, 40), 1.14f, Random.Range(-45, 45));
		 Vector3 rotation = new Vector3(0, Random.Range(0, 360), 0);
          Instantiate(follower,position2,Quaternion.Euler(rotation) );
        
	}
}
