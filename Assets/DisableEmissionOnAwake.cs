using UnityEngine;
using System.Collections;

public class DisableEmissionOnAwake : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GetComponent<ParticleSystem>().enableEmission = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
