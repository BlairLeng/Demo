using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {

	public string scene;
	public Color loadToColor = Color.white;

	// Use this for initialization
	void Start () {
		Initiate.Fade(scene,loadToColor,0.5f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
