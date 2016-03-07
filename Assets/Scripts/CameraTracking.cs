using UnityEngine;
using System.Collections;

public class CameraTracking : MonoBehaviour {

    public Transform target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = target.position;
        pos.y = gameObject.transform.position.y;
        gameObject.transform.position = pos;
	}
}
