using UnityEngine;
using System.Collections;

public class LightIntensity : MonoBehaviour {

	private Light l;

	void Start () {
		l = GetComponent<Light> ();
	}
	
	void Update () {
		if (Input.GetKeyDown ("space")) {
			l.intensity = 2f;
		} else {
			l.intensity = 0.1f;
		}
	}
}
