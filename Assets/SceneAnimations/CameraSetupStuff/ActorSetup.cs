using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ActorSetup : MonoBehaviour {
	
	private class TransformInfo {
		public Vector3 pos;
		public Quaternion rot;
		public Vector3 scale;

		public TransformInfo(Vector3 p, Quaternion r, Vector3 s) {
			pos = p;
			rot = r;
			scale = s;
		}
	}

	Dictionary<Transform, TransformInfo> actors;
	Dictionary<string, Transform> scenes;
	GameObject current;

	// Use this for initialization
	void Start () {
		scenes = new Dictionary<string, Transform>();
		foreach(Transform t in transform) {
			scenes.Add(t.name, t);
			t.gameObject.SetActive(false);
		}
		saveStartingTransforms(transform.GetChild(0).gameObject);
	}

	public void switchScene(string scene) {
		Transform next;
		scenes.TryGetValue(scene, out next);

		if(next == null) {
			Debug.LogError("Transform '" + scene + "' not found.");
			return;
		}

		restorePrevTransforms();
		saveStartingTransforms(next.gameObject);
	}

	private void saveStartingTransforms(GameObject scene) {
		actors = new Dictionary<Transform, TransformInfo>();

		foreach (Transform t in scene.transform) {
			actors.Add(t, new TransformInfo(
				t.position, t.rotation, t.localScale));
		}
		current = scene;
		current.SetActive(true);
	}

	private void restorePrevTransforms() {
		current.SetActive(false);

		foreach(KeyValuePair<Transform, TransformInfo> entry in actors) {
			entry.Key.position = entry.Value.pos;
			entry.Key.rotation = entry.Value.rot;
			entry.Key.localScale = entry.Value.scale;

			if(entry.Key.gameObject.GetComponent<Animator>() != null)
				entry.Key.gameObject.GetComponent<Animator>().Rebind();

			if(entry.Key.gameObject.GetComponent<RAIN.Core.AIRig>() != null)
				entry.Key.gameObject.GetComponent<RAIN.Core.AIRig>().AI.AIInit();
		}
	}
}
