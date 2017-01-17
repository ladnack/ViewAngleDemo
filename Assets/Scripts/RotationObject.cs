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
		if (GUILayout.Button ("Press Me")) {
			Debug.Log ("Hello!");
		}

		// Make a background box
		GUI.Box(new Rect (10, 10, 100, 90), "Loader Menu");

		// Make the first button. If it is pressed, Application.Loadlevel (1) will be executed
		if(GUI.Button(new Rect (20, 40, 80, 20), "Level 1")) {
			Application.LoadLevel (1);
		}

		// Make the second button.
		if(GUI.Button(new Rect (20, 70, 80, 20), "Level 2")) {
			Application.LoadLevel (2);
		}

		if (Time.time % 2 < 1) {
			if (GUI.Button (new Rect (10,10,200,20), "Meet the flashing button")) {
				print ("You clicked me!");
			}
		}

		// 画面４隅にBoxを表示
		GUI.Box (new Rect (0, 0, 100, 50), "Top-left");
		GUI.Box (new Rect (Screen.width - 100, 0, 100, 50), "Top-right");
		GUI.Box (new Rect (0, Screen.height - 50, 100, 50), "Bottom-left");
		GUI.Box (new Rect (Screen.width - 100, Screen.height - 50, 100, 50), "Bottom-right");

		// imegeとtextを一緒に表示する
		GUI.Box (new Rect (10, 10, 100, 50), new GUIContent ("This is text", icon));
	}

}
