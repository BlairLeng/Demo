using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class GabbyMovement : MonoBehaviour {


	NavMeshAgent nav;
	public GameObject des;

//	GameObject asd;
//	Controller qwe = asd.GetComponent<Controller>();
//	qwe
	public float speed = 10;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent> ();
		des = Controller.desFort;

	}
	
	// Update is called once per frame
	void Update () {
		move ();
	}

	public void move(){
		//if(Controller.counter >= 2){
//			Debug.Log (des);
//			gameObject.transform.position = Vector3.MoveTowards(gameObject.transform.position , Controller.desFort.transform.position, speed * Time.deltaTime);
//			Debug.Log (des);
//			Debug.Log(Controller.desFort);
			nav.SetDestination(des.transform.position);
	}


}

