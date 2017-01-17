using UnityEngine;
using System.Collections;

public class RotationObject : MonoBehaviour {

	public Texture2D icon;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUIpattern6 ();

	}

	// GUIパターン
	private void GUIpattern() {
		
	}

	// GUIパターン1
	private void GUIpattern1() {
		// Make a button
		if (GUILayout.Button ("Press Me")) {
			Debug.Log ("Hello!");
		}
	}

	// GUIパターン2
	private void GUIpattern2() {
		// Make a background box
		GUI.Box(new Rect (10, 10, 100, 90), "Loader Menu");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect (20, 40, 80, 20), "Level 1")) {
			Debug.Log ("Level 1!");
		}

		// Make the second button.
		if(GUI.Button(new Rect (20, 70, 80, 20), "Level 2")) {
			Debug.Log ("Level 2!");
		}
	}

	// GUIパターン3
	private void GUIpattern3() {
		// 点滅するButtonを作成
		if (Time.time % 2 < 1) {
			if (GUI.Button (new Rect (10,10,200,20), "Meet the flashing button")) {
				print ("You clicked me!");
			}
		}
	}

	// GUIパターン4
	private void GUIpattern4() {
		// 画面４隅にBoxを表示
		GUI.Box (new Rect (0, 0, 100, 50), "Top-left");
		GUI.Box (new Rect (Screen.width - 100, 0, 100, 50), "Top-right");
		GUI.Box (new Rect (0, Screen.height - 50, 100, 50), "Bottom-left");
		GUI.Box (new Rect (Screen.width - 100, Screen.height - 50, 100, 50), "Bottom-right");
	}

	// GUIパターン5
	private void GUIpattern5() {
		// imegeとtextを一緒に表示する
		GUI.Box (new Rect (10, 10, 100, 50), new GUIContent ("This is text", icon));
	}

	// GUIパターン6
	private void GUIpattern6() {
		// tooltipの表示
		GUI.Button (new Rect (10, 10, 100, 20), new GUIContent ("Click me", icon, "This is the tooltip"));
		GUI.Label (new Rect (10, 40, 100, 20), GUI.tooltip);
	}

}
