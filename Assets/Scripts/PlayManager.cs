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
	private float distance;

	// Use this for initialization
	void Start () {
		goal = Instantiate(goalprefab, new Vector3(UnityEngine.Random.Range(-30f, 30f), -80f, 0f), Quaternion.identity);
		goalposition = goal.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		distance = player.transform.localPosition.y - goalposition.y;
		TextManager.getText("残り" + distance.ToString() + "\n");
		if(player.transform.localPosition.x > goalposition.x){
		TextManager.addText("もっと左へ");
		}else if(player.transform.localPosition.x < goalposition.x){
			TextManager.addText("もっと右へ");
		}else{
			TextManager.addText("そこ");
		}
	}
}
