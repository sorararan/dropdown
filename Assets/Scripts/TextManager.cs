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
}
