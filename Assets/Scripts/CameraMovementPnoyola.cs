using UnityEngine;
using System.Collections;

public class CameraMovementPnoyola : MonoBehaviour {

	public float speed = 0.001f;
	public float turnSpeed = 2.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		transform.Translate (Vector3.forward * moveVertical * speed);
		transform.Rotate (Vector3.up * moveHorizontal * turnSpeed);

	}
}
