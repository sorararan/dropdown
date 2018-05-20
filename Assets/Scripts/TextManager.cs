using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextManager : MonoBehaviour {
	[SerializeField]
	private static Text txt;
	public static void getText(string text){
		txt.text = text;
	}

	public static void addText(string text){
		txt.text += text;
	}

	void Start(){
		txt = GameObject.Find("Text").GetComponent<Text>();
	}
}
