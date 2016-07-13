using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

	public Transform dest;
	NavMeshAgent nav;
	Animator anim;

	// Use this for initialization
	void Start () {
		nav = GetComponent<NavMeshAgent>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		nav.destination = dest.position;
		anim.SetFloat("Speed", nav.desiredVelocity.magnitude);

	}
}
