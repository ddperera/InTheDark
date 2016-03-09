using UnityEngine;
using System.Collections;

public class CharacterMovement : MonoBehaviour {

	public Rigidbody rb;
    public float speed;
    public Light flashlight;

	// Use this for initialization
	void Start () {
        rb = gameObject.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        Flashlight();
	}

    void FixedUpdate ()
    {
        Move();

        RotateToMouse();
    }

    void Move()
    {
        float h = Input.GetAxisRaw("Horizontal");
        float v = Input.GetAxisRaw("Vertical");

        Vector3 vel = new Vector3(h, 0, v);

        vel = vel.normalized * speed;

        rb.velocity = vel;
    }

    void RotateToMouse()
    {
        Vector3 v3T = Input.mousePosition;
        v3T.z = Mathf.Abs(Camera.main.transform.position.y - transform.position.y);
        v3T = Camera.main.ScreenToWorldPoint(v3T);
        transform.LookAt(v3T);
    }

    void Flashlight()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            flashlight.enabled = !flashlight.enabled;
        }
    }
}
