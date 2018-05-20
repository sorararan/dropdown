using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
	private Vector3 startpos = new Vector3 (0, 70, 0);
	private Rigidbody rb;
	[SerializeField]
	private float speed = 0.05f;
	[SerializeField]
	private float stopspeed = -20f;
	public bool stop;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		stop = false;
		rb.constraints = RigidbodyConstraints.FreezeAll;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Return)) {
			rb.constraints = RigidbodyConstraints.None;
		}
		if (PlayManager.start) {
			if (rb.velocity.y < stopspeed) {
				rb.velocity = new Vector3 (rb.velocity.x, stopspeed, rb.velocity.z);
			}
			if (Input.GetKey (KeyCode.RightArrow)) {
				this.transform.position += transform.right * speed * Time.deltaTime;
			}
			if (Input.GetKey (KeyCode.LeftArrow)) {
				this.transform.position -= transform.right * speed * Time.deltaTime;
			}
			if (Input.GetKeyDown (KeyCode.Space)) {
				rb.constraints = RigidbodyConstraints.FreezeAll;
				stop = true;
			}
		}
	}

	void OnCollisionEnter (Collision collision) {
		stop = true;
		rb.constraints = RigidbodyConstraints.FreezeAll;
	}

	public void init () {
		this.stop = false;
		this.transform.localPosition = startpos;
		rb.constraints = RigidbodyConstraints.None;
	}
}