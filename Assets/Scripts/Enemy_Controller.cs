using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Controller : MonoBehaviour {
	private int counter = 100;
	private int counter_stop = 100;
	private float plusx;
	private float plusy;
	private const float plusz = 0f;

	// Update is called once per frame
	void Update () {
		if (counter < counter_stop) {
			this.transform.localPosition += new Vector3 (plusx, plusy, plusz);
			counter++;
		}else{
			plusx = UnityEngine.Random.Range (-0.5f, 0.5f);
			plusy = UnityEngine.Random.Range (-0.5f, 0.5f);
			counter = 0;
		}
	}
}