using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ButtonCustomOnClick : MonoBehaviour {


	public void SetLabelText (string str) {
		Text text = GameObject.Find ("MainText").GetComponent<Text> ();
		text.text = str;
		Debug.Log ("LabelText()");
	}

	public void IndirectOnClick(){
		Button mainButton = GameObject.Find ("MainButton").GetComponent<Button> ();
		// 別のbuttonのイベント処理を引き起こす
		mainButton.onClick.Invoke ();
	}


}
