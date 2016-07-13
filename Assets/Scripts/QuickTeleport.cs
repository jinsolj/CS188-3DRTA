using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class QuickTeleport : MonoBehaviour {
	public Transform FPSCamera;
	public Light DirectionLight;
	public float skyRotateSpeed = 1;
	
	private List<Transform> teleportPoints;
	private int curIndex = 0;
	private float skyRotateFloat = 0;

	// Use this for initialization
	void Start () {
		teleportPoints = new List<Transform>();
		foreach (Transform t in transform) {
			teleportPoints.Add (t);
		}
		skyRotateFloat = RenderSettings.skybox.GetFloat("_Rotation");
	}
	
	// Update is called once per frame
	void Update () {
		skyRotateFloat = (skyRotateFloat + (skyRotateSpeed * Time.deltaTime)) % 360;
		RenderSettings.skybox.SetFloat("_Rotation", skyRotateFloat);

		if(Input.GetKeyDown(KeyCode.Alpha1)) {
			curIndex = (curIndex + teleportPoints.Count - 1) % teleportPoints.Count;
			FPSCamera.transform.position = teleportPoints[curIndex].position;
		}
		else if(Input.GetKeyDown (KeyCode.Alpha2)) {
			curIndex = (curIndex + 1) % teleportPoints.Count;
			FPSCamera.transform.position = teleportPoints[curIndex].position;
		}

		if(Input.GetKeyDown(KeyCode.F)) {
			DirectionLight.intensity = DirectionLight.intensity == 0.15f ? 0.9f : 0.15f;
		}
	}
}
