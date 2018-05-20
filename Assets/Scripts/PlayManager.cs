using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {
	[SerializeField]
	private GameObject goal;
	[SerializeField]
	private GameObject player;
	// Use this for initialization
	void Start () {
		Instantiate(goal, new Vector3(UnityEngine.Random.Range(-30f, 30f), -80f, 0f), Quaternion.identity);

	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.localPosition.x > goal.transform.localPosition.x){
			TextManager.getText("もっと左へ");
		}else if(player.transform.localPosition.x < goal.transform.localPosition.x){
			TextManager.getText("もっと右へ");
		}else{
			TextManager.getText("そこ");
		}
	}
}
