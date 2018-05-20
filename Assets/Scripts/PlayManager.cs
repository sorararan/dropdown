using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {
	//クリア判定
	public static bool clear = false;
	//敵の数
	private int enemy_num = 10;
	//プレイ中はtrue
	public static bool start;
	//敵のprefab
	[SerializeField]
	private GameObject enemyprefab;
	//矢印のprefab
	[SerializeField]
	private GameObject arrowprefab;
	//ゴールのprefab
	[SerializeField]
	private GameObject goalprefab;
	//敵オブジェクト
	GameObject[] enemy;
	//ゴールオブジェクト
	private GameObject goal;
	//矢印オブジェクト
	private GameObject arrow;
	//プレイヤオブジェクト
	[SerializeField]
	private GameObject player;
	//ゴールの位置
	private Vector3 goalposition;
	//プレイヤとゴールの距離
	private float distance;
	//スコア
	private float score;

	// Use this for initialization
	void Start () {
		enemy = new GameObject[enemy_num];
		TextManager.getText ("エンターを押すとスタート");
		start = false;
	}

	// Update is called once per frame
	void Update () {
		//プレイ中でないのでエンター押し待ち
		if (!start && Input.GetKeyDown (KeyCode.Return)) {
			//プレイヤ初期化
			player.GetComponent<Player_Controller> ().init ();
			player.GetComponent<Rigidbody> ().constraints = RigidbodyConstraints.None;
			//矢印生成
			arrow = Instantiate (arrowprefab, (player.transform.localPosition + new Vector3 (0, -2, 0)), Quaternion.identity);
			//敵生成
			for (int i = 0; i < enemy_num; i++) {
				enemy[i] = Instantiate (enemyprefab, new Vector3 (
					UnityEngine.Random.Range (-30f, 30f),
					UnityEngine.Random.Range (-90f, 90f),
					0f), Quaternion.identity);
			}
			//ゴール生成
			goal = Instantiate (goalprefab, new Vector3 (UnityEngine.Random.Range (-30f, 30f), -80f, 0f), Quaternion.identity);
			goalposition = goal.transform.position;
			clear = false;
			start = true;
		}
		//プレイスタート
		if (start) {
			//プレイヤが止まったらプレイ終了
			if (!player.GetComponent<Player_Controller> ().stop) {
				//矢印をゴールに向かせる
				arrow.transform.localPosition = player.transform.localPosition + new Vector3 (0, -2f, 0);
				arrow.transform.localEulerAngles = goal.transform.localPosition - player.transform.localPosition + new Vector3 (0, 0, -90f);
				//ゴールまで残りのy
				distance = player.transform.localPosition.y - goalposition.y;
				TextManager.getText ("残り" + distance.ToString () + "\n");
				//ゴールのxの指示
				if (player.transform.localPosition.x > goalposition.x) {
					TextManager.addText ("もっと左へ");
				} else if (player.transform.localPosition.x < goalposition.x) {
					TextManager.addText ("もっと右へ");
				} else {
					TextManager.addText ("そこ");
				}
			} else {
				//プレイヤが止まってプレイ終了
				//スコアの計算
				score = 10f - Vector3.Distance (player.transform.localPosition, goal.transform.localPosition);
				TextManager.getText ("score: " + score.ToString () + "\n");
				Destroy (arrow);
				for (int i = 0; i < enemy_num; i++) {
					Destroy (enemy[i]);
				}
				Destroy (goal);
				//クリア判定
				if (clear) {
					TextManager.addText ("clear\n");
				} else {
					TextManager.addText ("not clear\n");
				}
				TextManager.addText ("エンターで再挑戦");
				start = false;
			}
		}
	}
}