using UnityEngine;
using System.Collections;

public class MusicManager : MonoBehaviour {
	public AudioClip[] songs;
	AudioSource src;
	int index = 0;
	Animator anim;

	// Use this for initialization
	void Start () {
		src = GetComponent<AudioSource>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		if(!src.isPlaying) {
			anim.SetTrigger("songEnded");
		}
	}

	public void playSong(string song) {
		foreach(AudioClip s in songs) {
			if(s.name == song) {
				src.clip = s;
				src.Play();
				return;
			}
		}
		Debug.LogError("Error: " + song + " was not found.");
	}
}
