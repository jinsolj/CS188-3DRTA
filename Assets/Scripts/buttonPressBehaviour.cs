using UnityEngine;
using System.Collections;

public class buttonPressBehaviour : MonoBehaviour {

	AudioSource aud;
	Animator anim;
	Light on;

	void Start() {
		anim = GetComponentInChildren<Animator>();
		aud = GetComponent<AudioSource>();
		on = GetComponentInChildren<Light>();
	}

	public void runFunc() {
		anim.SetTrigger("pressed");
		aud.Play();
		on.gameObject.SetActive(false);
	}
}
