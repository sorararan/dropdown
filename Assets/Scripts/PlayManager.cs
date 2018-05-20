using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {
	private int enemy_num = 20;
	[SerializeField]
	private GameObject enemyprefab;
	GameObject[] enemy;
	public static bool start;
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
		enemy = new GameObject[enemy_num];
		arrow = Instantiate (arrowprefab, (player.transform.localPosition + new Vector3 (0, -2f, 0)), Quaternion.identity);
		goal = Instantiate (goalprefab, new Vector3 (UnityEngine.Random.Range (-30f, 30f), -80f, 0f), Quaternion.identity);
		goalposition = goal.transform.position;
		TextManager.getText ("エンターを押すとスタート");
		start = false;
	}

	// Update is called once per frame
	void Update () {
		if (!start && Input.GetKeyDown (KeyCode.Return)) {
			start = true;
			for(int i = 0; i < enemy_num; i++){
				enemy[i] = Instantiate(enemyprefab, new Vector3(
					UnityEngine.Random.Range (-30f, 30f), 
					UnityEngine.Random.Range(-90f, 90f), 
					0f), Quaternion.identity);
			}
		}
		if (start) {
			if (!player.GetComponent<Player_Controller> ().stop) {
				arrow.transform.localPosition = player.transform.localPosition + new Vector3 (0, -2f, 0);
				arrow.transform.localEulerAngles = goal.transform.localPosition - player.transform.localPosition + new Vector3 (0, 0, -90f);
				distance = player.transform.localPosition.y - goalposition.y;
				TextManager.getText ("残り" + distance.ToString () + "\n");
				if (player.transform.localPosition.x > goalposition.x) {
					TextManager.addText ("もっと左へ");
				} else if (player.transform.localPosition.x < goalposition.x) {
					TextManager.addText ("もっと右へ");
				} else {
					TextManager.addText ("そこ");
				}
			} else {
				score = 10f - Vector3.Distance (player.transform.localPosition, goal.transform.localPosition);
				TextManager.getText ("score: " + score.ToString () + "\n");
				Destroy (arrow);
				for(int i = 0; i < enemy_num; i++){
					Destroy(enemy[i]);
				}
				start = false;
				TextManager.addText("エンターで再挑戦");
				if(Input.GetKeyDown(KeyCode.Return)){
					arrow = Instantiate (arrowprefab, (player.transform.localPosition + new Vector3 (0, -2, 0)), Quaternion.identity);
					for(int i = 0; i < enemy_num; i++){
				enemy[i] = Instantiate(enemyprefab, new Vector3(
					UnityEngine.Random.Range (-30f, 30f), 
					UnityEngine.Random.Range(-90f, 90f), 
					0f), Quaternion.identity);
			}
					player.GetComponent<Player_Controller>().init();
					start = true;
				}
			}
		}
	}
}