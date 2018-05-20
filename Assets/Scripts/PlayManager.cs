using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {
	[SerializeField]
	private GameObject arrowprefab;
	[SerializeField]
	private GameObject goalprefab;
	private GameObject goal;
	private GameObject arrow;
	[SerializeField]
	private GameObject player;
	private Vector3 goalposition;
	private float distance;
	private float score;

	// Use this for initialization
	void Start () {
		arrow = Instantiate (arrowprefab, (player.transform.localPosition + new Vector3 (0, -2, 0)), Quaternion.identity);
		goal = Instantiate (goalprefab, new Vector3 (UnityEngine.Random.Range (-30f, 30f), -80f, 0f), Quaternion.identity);
		goalposition = goal.transform.position;
	}

	// Update is called once per frame
	void Update () {
		if (!player.GetComponent<Player_Controller> ().stop) {
			arrow.transform.localPosition = player.transform.localPosition + new Vector3 (0, -2, 0);
			arrow.transform.localEulerAngles = goal.transform.localPosition - player.transform.localPosition + new Vector3 (0, 0, -90);
			distance = player.transform.localPosition.y - goalposition.y;
			TextManager.getText ("残り" + distance.ToString () + "\n");
			if (player.transform.localPosition.x > goalposition.x) {
				TextManager.addText ("もっと左へ");
			} else if (player.transform.localPosition.x < goalposition.x) {
				TextManager.addText ("もっと右へ");
			} else {
				TextManager.addText ("そこ");
			}
		}else {
			score = 10f - Vector3.Distance (player.transform.localPosition, goal.transform.localPosition);
			TextManager.getText ("score: " + score.ToString ());
			Destroy (arrow);
		}
	}
}