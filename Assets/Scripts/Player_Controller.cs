using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
	private Rigidbody rb;
	[SerializeField]
	private float speed = 10f;
	[SerializeField]
	private float stopspeed = -20f;
	public bool stop;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		stop = false;
	}

	// Update is called once per frame
	void Update () {
		if (rb.velocity.y < stopspeed) {
			rb.velocity = new Vector3 (rb.velocity.x, stopspeed, rb.velocity.z);
		}
		if (Input.GetKey (KeyCode.RightArrow)) {
			rb.AddForce (transform.right * speed);
		}
		if (Input.GetKey (KeyCode.LeftArrow)) {
			rb.AddForce (-transform.right * speed);
		}
		if (Input.GetKeyDown (KeyCode.Space)) {
			if (stop) {
				rb.constraints = RigidbodyConstraints.None;
				stop = !stop;
			} else {
				rb.constraints = RigidbodyConstraints.FreezeAll;
				stop = !stop;
			}
		}
	}
}