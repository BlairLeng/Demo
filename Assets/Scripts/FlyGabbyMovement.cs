using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyGabbyMovement : MonoBehaviour {


	public GameObject des;
	// Use this for initialization
	void Start () {
		des = Controller.desFort;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction = (des.transform.position - transform.position).normalized;
		GetComponent<CharacterController> ().Move (direction * Time.deltaTime * 4);
	}
}
