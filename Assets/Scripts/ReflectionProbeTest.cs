using UnityEngine;
using System.Collections;

public class ReflectionProbeTest : MonoBehaviour {

	ReflectionProbe rp;

	// Use this for initialization
	void Start () {
		rp = GetComponentInChildren<ReflectionProbe>();
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<MeshRenderer>().material.SetTexture( "_Cube", rp.texture);
	}
}
