using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//sdgsdljslssfdsfs
public class GabbyController : MonoBehaviour {

	public int numberOfMovingSoldiers;
	float AttackRange = 12;
	public float AttackCD = 100000f;
	//	GameObject AttackTarget;
	//	public GameObject others;
	private float __time = 0;
	public bool GoodOrNot;

	void Start () {
		
		Debug.Log ("start " +numberOfMovingSoldiers);
	}

	// Update is called once per frame
	void Update () {
		__time += Time.deltaTime;
		if (__time >= AttackCD) {
			__time = 0;

			detectRange ();

			//			if (AttackTarget == null) {
			//				AttackTarget = GetTargetAttack ();
			////				Debug.Log (AttackTarget);
			////				Debug.Log(IsTarget(AttackTarget));
			//			}
			//			if (IsTarget(AttackTarget)) {
			//				Debug.Log ("attack");
			//			}
		}
	}

	//	public bool IsTarget(GameObject other){
	////		Debug.Log (Vector3.Distance (transform.position, others.transform.position));
	//		if (Vector3.Distance (transform.position, others.transform.position) <= AttackRange) {
	////			Debug.Log(Vector3.Distance(transform.position, others.transform.position));
	//			return true; 
	//		} else {
	//			return false;
	//		}
	//	}
	//
	//
	//
	//
	//	public GameObject GetTargetAttack(){
	////		Debug.Log (others);
	//		float distance = Vector3.Distance (transform.position, others.transform.position);
	//		Debug.Log(distance);
	//		if (distance <= AttackRange) {
	//			return others; 
	//		}
	//		return null;
	//
	//	}
	//
	public void detectRange(){

		Collider[] hitColliders = Physics.OverlapSphere (transform.position, 5);
		for (int i = 0; i < hitColliders.Length; i++)
		{
			if (hitColliders [i].gameObject == GameObject.Find ("BadGabby(Clone)") && gameObject.name == "Gabby(Clone)") {




				GabbyController badgab = hitColliders [i].gameObject.GetComponent<GabbyController>();

				Debug.Log ("before gab is " + numberOfMovingSoldiers + "badgab is" + badgab.numberOfMovingSoldiers);

				int sum = numberOfMovingSoldiers + badgab.numberOfMovingSoldiers;
				numberOfMovingSoldiers = numberOfMovingSoldiers - (badgab.numberOfMovingSoldiers)/5 ;


				Debug.Log ("now gabby is" + numberOfMovingSoldiers );
				Debug.Log ("now badgabby is" + badgab.numberOfMovingSoldiers);


			}
			else if (hitColliders [i].gameObject == GameObject.Find ("Gabby(Clone)") && gameObject.name == "BadGabby(Clone)") {

				GabbyController badgab = hitColliders [i].gameObject.GetComponent<GabbyController>();

				Debug.Log ("before gab is " + numberOfMovingSoldiers + "badgab is" + badgab.numberOfMovingSoldiers);

				int sum = numberOfMovingSoldiers + badgab.numberOfMovingSoldiers;
				numberOfMovingSoldiers = numberOfMovingSoldiers - (badgab.numberOfMovingSoldiers)/5 ;


				Debug.Log ("now gabby is" + badgab.numberOfMovingSoldiers );
				Debug.Log ("now badgabby is" + numberOfMovingSoldiers);


			}
		}
	} 
}