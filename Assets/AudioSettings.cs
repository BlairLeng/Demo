using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSettings : MonoBehaviour {

	FMOD.Studio.EventInstance TestEvent;
	FMOD.Studio.Bus Music;
	float MusicVolume = 1f;


	void Awake()
	{ 
		Music = FMODUnity.RuntimeManager.GetBus ("bus:/Master/Music");

	}





	void Update () {
		Music.setVolume (MusicVolume);
	}

	public void MusicVolumeLevel (float newMusicVolume){
		MusicVolume = newMusicVolume;

//		FMOD.Studio.PLAYBACK_STATE pbState;
//		Music.getPlaybackState (out pbState);
//		if(pbState != FMOD.Studio.PLAYBACK_STATE.PLAYING){
//			Music.start ();
//		}
	}
}
