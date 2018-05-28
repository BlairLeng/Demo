using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Button start;
	public Button treasure;
	public static int scencenum = 0;
	// Use this for initialization
	void Start () {
		Button btn = start.GetComponent<Button>();
		Button daoju = treasure.GetComponent<Button> ();
		btn.onClick.AddListener(TaskOnClick);
		daoju.onClick.AddListener (DaojuOnClick);
	}
	
	// Update is called once per frame



	public void TaskOnClick(){
		SceneManager.LoadScene ("final 1.2");
		scencenum = 1;
	}
	public void DaojuOnClick(){
		SceneManager.LoadScene ("Daoju");
	}

}
