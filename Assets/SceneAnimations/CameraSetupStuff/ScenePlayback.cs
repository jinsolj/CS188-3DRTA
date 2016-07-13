using UnityEngine;
using System.Collections;

public class ScenePlayback : MonoBehaviour {
	Animator anim;
	ThirdPersonOrbitCam camControl;
	PlayerControl playerControl;

	Vector3 defaultControlCamPos;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
		if(Camera.main == null)
			Debug.LogError("There is no camera tagged main.");
		else {
			camControl = Camera.main.gameObject.GetComponent<ThirdPersonOrbitCam>();
		}
		playerControl = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControl>();

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.F))
			anim.SetTrigger("next");
		else if(Input.GetKeyDown(KeyCode.B))
			anim.SetTrigger("prev");

		if(anim.GetCurrentAnimatorStateInfo(0).IsName("end") && Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	Vector3 getDefaultControlPos() {
		return playerControl.gameObject.transform.position + camControl.camOffset;
	}

	public void Anim2Control(bool final = false) {
		if(!final) {
			//anim.SetTrigger("animationOff");
			camControl.enabled = true;
		}
		else {
			anim.SetTrigger("animationOff");
			Vector3 startPos = camControl.gameObject.transform.position;
			Vector3 endPos = getDefaultControlPos();
		}
	}

	public void Control2Anim(bool final = false) {
		if(!final) {
			camControl.enabled = false;
			//anim.Play (stateName);
		}
		else {
			Vector3 startPos = camControl.gameObject.transform.position;
		}
	}


}
