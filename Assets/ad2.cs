using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ad2 : MonoBehaviour {

	[FMODUnity.EventRef]
	public string selectsound1;

	FMOD.Studio.EventInstance soundevent1;


	//public KeyCode presstoplaysound;


	void Start () {

		soundevent1 = FMODUnity.RuntimeManager.CreateInstance (selectsound1);

	}

	// Update is called once per frame
	void Update () {

		Playsound ();

	}

	void Playsound()
	{

      soundevent1.start ();

		 
	}

}

