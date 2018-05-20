using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour {
	private bool muteki;
	//無敵時間のスコア減少分
	private int mcounter;
	//プレイヤのスタート位置
	private Vector3 startpos = new Vector3 (0, 90, 0);
	private Rigidbody rb;
	//横移動スピード
	[SerializeField]
	private float speed = 0.05f;
	//落下速度制限
	[SerializeField]
	private float stopspeed = -30f;
	//止まったらプレイ終了してスコア判定
	private bool stop;

	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody> ();
		stop = false;
		//一番初めはエンター待ちなので
		rb.constraints = RigidbodyConstraints.FreezeAll;
		mcounter = 0;
		muteki = false;
	}

	// Update is called once per frame
	void FixedUpdate () {
		//スタート
		if (PlayManager.getStart()) {
			//落下速度制限
			if (rb.velocity.y < stopspeed) {
				rb.velocity = new Vector3 (rb.velocity.x, stopspeed, rb.velocity.z);
			}
			//右移動
			if (Input.GetKey (KeyCode.RightArrow)) {
				this.transform.position += transform.right * speed * Time.deltaTime;
			}
			//左移動
			if (Input.GetKey (KeyCode.LeftArrow)) {
				this.transform.position -= transform.right * speed * Time.deltaTime;
			}
			if(Input.GetKeyDown(KeyCode.B)){
				this.GetComponent<SphereCollider>().isTrigger = true;
				muteki = true;
			}
			if(muteki){
				mcounter++;
			}
			
			//プレイヤ停止して判定
			if (Input.GetKeyDown (KeyCode.Space)) {
				rb.constraints = RigidbodyConstraints.FreezeAll;
				stop = true;
			}
		}
	}
	
	//敵や壁に当たったら即not clear
	void OnCollisionEnter (Collision collision) {
		stop = true;
		rb.constraints = RigidbodyConstraints.FreezeAll;
	}

	//ゴール内で止まればclear
	void OnTriggerEnter(Collider collider)
	{
		PlayManager.clear = true;
	}

	//ゴール外に出たのでnot clear
	void OnTriggerExit(Collider collider)
	{
		PlayManager.clear = false;
	}

	//プレイヤの初期化
	public void init () {
		this.stop = false;
		this.transform.localPosition = startpos;
		rb.constraints = RigidbodyConstraints.None;
		mcounter = 0;
		muteki = false;
		this.GetComponent<SphereCollider>().isTrigger = false;
	}
	public bool getStop(){
		return this.stop;
	}

	public int getCounter(){
		return this.mcounter;
	}
}