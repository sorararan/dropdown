using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
	Rigidbody rb;
	float speed = 10f;
	float stopspeed = -20f;
	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		if(rb.velocity.y < stopspeed){
			rb.velocity = new Vector3(rb.velocity.x, stopspeed, rb.velocity.z);
		}
		Debug.Log ("速度ベクトル: " + rb.velocity);
		if(Input.GetKey(KeyCode.RightArrow)){
			rb.AddForce(transform.right * speed);
		}
		if(Input.GetKey(KeyCode.LeftArrow)){
			rb.AddForce(-transform.right * speed);
		}
	}
}
