using UnityEngine;
using System.Collections;

public class DoorInteract : Interactable {

	[Tooltip("If a door knob is on the left, then it opens away from you.")]
	public bool startReverseDirection = false;
	
	public AudioClip openSound;
	public AudioClip closeSound;

	private AudioSource aud;

	private bool isOpen = false;
	private bool isSwitched = false;

	private float openRot = 80f;
	private float closedRot = 1f;
	private float goalRot = 1f;

	private float resetTime = 0f;

	private MeshCollider meshCol;

	private bool isLocked = false;

	void Start() {
		if(startReverseDirection) {
			switchDirection();
		}
		aud = GetComponent<AudioSource>();
		meshCol = GetComponent<MeshCollider>();
	}

	// Interpolate door rotation to its goal rotation.
	void Update () {
		transform.rotation = Quaternion.Euler (new Vector3(
			transform.rotation.eulerAngles.x,
			Mathf.Lerp(transform.rotation.eulerAngles.y, goalRot, 0.2f),
			transform.rotation.eulerAngles.z));

		if(Input.GetKeyDown(KeyCode.R) && !isOpen) {
			switchDirection();
		}

		if(resetTime >= 0) 
			resetTime -= Time.deltaTime;
	}

	
	void OnTriggerEnter(Collider other) {
		if(!isLocked)
			Interact ();
	}
	
	public override void Interact() {
		toggleDoor();
		Debug.Log("Colliding");
	}

	//Toggles the goal rotation between open and close, checking the refresh timer
	//Door collider temporarily disabled to prevent push character away.
	public void toggleDoor() {
		if(resetTime < 0) {
			aud.PlayOneShot(isOpen ? closeSound : openSound);

			goalRot = isOpen ? closedRot : openRot;
			isOpen = !isOpen;
			resetTime = 0.5f;
		}
		meshCol.enabled = false;
		StartCoroutine("tempDisableDoorCollision");
	}

	public IEnumerator tempDisableDoorCollision() {
		yield return new WaitForSeconds(.2f);
		meshCol.enabled = true;
	}

	public void ToggleLock() {
		isLocked = !isLocked;
	}

	//Switch the way a door opens. Only works on closed doors.
	//A bit more complex than initially thought, since negative rotations
	//are automatically rolled over past 360.
	void switchDirection() {
		isSwitched = !isSwitched;

		openRot = isSwitched ? 280f : 80f;
		closedRot = isSwitched ? 359.99f : .01f;
		goalRot = closedRot;


		if(!isOpen) {
			transform.rotation = Quaternion.Euler (new Vector3(
				transform.rotation.eulerAngles.x,
				closedRot,
				transform.rotation.eulerAngles.z));
		}
	}
}
