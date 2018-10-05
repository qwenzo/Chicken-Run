using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MonsterManager : MonoBehaviour {
   private GameObject laser;
   private Animator anim;
   public NavMeshAgent navMeshAgent;

   public bool isEnargized;

   public bool cancelInvoke;

   public float movSpeed = 10f;

   public Material material;

   public bool isControlled;

   public bool isBoss;

   [SerializeField] float laserSpeed {
	   set;
	   get;
   }
	// Use this for initialization
	void Start () {
		cancelInvoke = false;
		isEnargized = false;
		isControlled = false;
		isBoss = false;
		Transform DragonChildTrans= transform.Find("Dragon");
		GameObject DragonChild = DragonChildTrans.gameObject;
		Transform DragonChildTrans2= DragonChild.transform.Find("Dragon");
		GameObject DragonChild2 = DragonChildTrans2.gameObject;
		 Renderer rend = DragonChild2.GetComponent<Renderer>();
		 material=rend.material;
		anim = GetComponent<Animator>();
		//print(anim.get);
		navMeshAgent = GetComponent<NavMeshAgent>();
		laserSpeed = 1.5f;
		 laser = transform.GetChild (0).gameObject;
		  Invoke("visibleMonsterLaser",laserSpeed);
	      InvokeRepeating("Move", 5, 5);
		  
	}
	
	// Update is called once per frame
	void Update () {
		//anim.Play("Attack_animation");
		//transform.Translate(new Vector3(0.3f,0,0));
	
	}


	void visibleMonsterLaser(){
       laser.SetActive(true);
	}

	void invisibleMonsterLaser(){
       laser.SetActive(false);
	}

	public void Move(){
		if(!isControlled && !isBoss){
		invisibleMonsterLaser();
		Vector3 currPos = transform.position;
		Vector3 position2 = new Vector3(currPos.x+Random.Range(-15,15), 2.703f, currPos.y+Random.Range(-15,15));
		if(isEnargized){
            position2 = new Vector3(currPos.x+Random.Range(-45,45), 2.703f, currPos.y+Random.Range(-45,45));
		}
		navMeshAgent.SetDestination(position2);
		//navMeshAgent.enabled=false;
		 Invoke("finishMov",3f);

		}
		 
	}

 private void finishMov(){
		 visibleMonsterLaser();
		 anim.Play("Attack_animation");
		//navMeshAgent.enabled=true;
 }

	
	 
	}

	

