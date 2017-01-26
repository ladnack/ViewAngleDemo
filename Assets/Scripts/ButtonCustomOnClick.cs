using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonCustomOnClick : MonoBehaviour {


	public void LabelText (string str) {
		Text text = GameObject.Find ("Text").GetComponent<Text> ();
		text.text = str;
		Debug.Log ("LabelText()");
	}

}
