using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class audiotest : MonoBehaviour {

	[FMODUnity.EventRef]
	public string selectsound;

	FMOD.Studio.EventInstance soundevent;


	public KeyCode presstoplaysound;


	void Start () {
		
		soundevent = FMODUnity.RuntimeManager.CreateInstance (selectsound);

	}
	
	// Update is called once per frame
	void Update () {
		
	    Playsound ();


	}

	void Playsound()
	{

		if (Input.GetKeyDown (presstoplaysound) && GameManager.scencenum == 0) {
			
			soundevent.start ();

		} 
}

}

