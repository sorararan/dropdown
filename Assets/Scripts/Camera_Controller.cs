using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {
	GameObject player;
	Vector3 position;
	// Use this for initialization
	void Start () {
		player = GameObject.Find("player");
	}
	
	// Update is called once per frame
	void Update () {
		position = player.transform.localPosition;
		position.z -= 10;
		this.transform.localPosition = position;
	}
}
