using UnityEngine;
using System.Collections;

public class CameraMovementPnoyola : MonoBehaviour {

	public Transform obj;
	public float speed = 1.0f;

	void Update(){
		Vector3 pos = new Vector3 (obj.position.x, 7f, obj.position.z - 0.5f);
		transform.position = Vector3.Slerp (transform.position, pos, speed);
	}

}
