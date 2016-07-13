using UnityEngine;
using System.Collections;

public class grabHand : MonoBehaviour {

	public GameObject hand;
	public bool enableIK = true;
	Animator anim;
	float totalTime = 3.375f;
	float curTime = 0f;

	void Start() {
		anim = GetComponent<Animator>();
	}

	void Update() {
		curTime += Time.deltaTime;
		if(curTime > totalTime) {
			enableIK = false;
		}
	}

	void OnAnimatorIK() {
		if(enableIK) {
			anim.SetIKPositionWeight(AvatarIKGoal.RightHand,1);
			//anim.SetIKRotationWeight(AvatarIKGoal.RightHand,1);  
			anim.SetIKPosition(AvatarIKGoal.RightHand, hand.transform.position);
			//anim.SetIKRotation(AvatarIKGoal.RightHand,hand.transform.rotation);
		}
	}
}
