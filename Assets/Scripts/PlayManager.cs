using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayManager : MonoBehaviour {
	[SerializeField]
	private GameObject goalprefab;
	private GameObject goal;
	[SerializeField]
	private GameObject player;
	private Vector3 goalposition;

	// Use this for initialization
	void Start () {
		goal = Instantiate(goalprefab, new Vector3(UnityEngine.Random.Range(-30f, 30f), -80f, 0f), Quaternion.identity);
		goalposition = goal.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if(player.transform.localPosition.x > goalposition.x){
			TextManager.getText("もっと左へ");
		}else if(player.transform.localPosition.x < goalposition.x){
			TextManager.getText("もっと右へ");
		}else{
			TextManager.getText("そこ");
		}
	}
}
