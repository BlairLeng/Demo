using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OnClickOnSettings: MonoBehaviour
{
	public Button yourButton;
	public Button helpButton;
	public Button SoundButton;
	public Button MuteButton;
	public static bool isSound;

	void Start()
	{
		isSound = true;
		Button btn = yourButton.GetComponent<Button>();
		Button sound = SoundButton.GetComponent<Button> ();
		Button mute = MuteButton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		sound.onClick.AddListener (SoundOnClick);
		mute.onClick.AddListener (SoundOnClick);
		SoundButton.gameObject.SetActive (false);
		helpButton.gameObject.SetActive (false);
		MuteButton.gameObject.SetActive (false);

	}

	void SoundOnClick(){
		if (SoundButton.gameObject.activeSelf) {
			SoundButton.gameObject.SetActive (false);
			MuteButton.gameObject.SetActive (true);
			isSound = false;
		} 
		else {
			SoundButton.gameObject.SetActive (true);
			MuteButton.gameObject.SetActive (false);
			isSound = true;
		}
	}




	void TaskOnClick()
	{

		if (!helpButton.gameObject.activeSelf) {
			if (isSound) {
				MuteButton.gameObject.SetActive (false);
				SoundButton.gameObject.SetActive (true);

			} else {
				SoundButton.gameObject.SetActive (false);
				MuteButton.gameObject.SetActive (true);

			}
		}

		if (helpButton.gameObject.activeSelf) {
			helpButton.gameObject.SetActive (false);
			SoundButton.gameObject.SetActive (false);
			MuteButton.gameObject.SetActive (false);
		} else {
			helpButton.gameObject.SetActive (true);
		}


	}
}