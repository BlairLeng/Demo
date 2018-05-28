using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class login : MonoBehaviour {
	private string scene= "UI-Scene";
	private Color loadToColor = Color.white;
	public Button start;

	// Use this for initialization
	void Start () {
		Button btn = start.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
	}

	// Update is called once per frame
	public void TaskOnClick(){

		Initiate.Fade(scene,loadToColor,0.5f);
	}
}
