using UnityEngine;
using System.Collections;

public class LightPnoyola : MonoBehaviour {

	
	private Light l;
	
	void Start () {
		l = GetComponent<Light> ();
	}
	
	void Update () {
		if (Input.GetKey ("space")) {
			l.intensity = 4f;
		} else {
			l.intensity = 0.1f;
		}
	}
}
