using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Controller : MonoBehaviour {
	[SerializeField]
	private GameObject player;
	private Vector3 position;
	
	// Update is called once per frame
	void Update () {
		position = player.transform.localPosition;
		position.z -= 10;
		this.transform.localPosition = position;
	}
}
