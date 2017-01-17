using UnityEngine;
using System.Collections;

public class RotationObject : MonoBehaviour {

	public Texture2D icon;

	public GUIStyle customButton;

	public GUISkin mySkin;
	private bool toggle = true;

	private float sliderValue = 1.0f;
	private float maxSliderValue = 10.0f;

	private float mySlider = 1.0f;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI() {

		GUIpattern14 ();

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

	// GUIパターン7
	private void GUIpattern7() {
		// Make a label that uses the "box" GUIStyle.
		GUI.Label (new Rect (0, 0, 200, 100), "Hi - I'm a label looking like a box", "box");

		// Make a button that uses the "toggle" GUIStyle
		GUI.Button (new Rect (10, 140, 180, 20), "This is a button", "toggle");
	}

	// GUIパターン8
	private void GUIpattern8() {
		// Make a button. We pass in the GUIStyle defined above as the style to use
		GUI.Button (new Rect (10, 10, 150, 20), "I am a Custom Button", customButton);
	}

	// GUIパターン9
	private void GUIpattern9() {
		//Set the GUIStyle style to be label
		GUIStyle style = GUI.skin.GetStyle ("label");

		//Set the style font size to increase and decrease over time
		style.fontSize = (int)(20.0f + 10.0f * Mathf.Sin (Time.time));

		//Create a label and display with the current settings
		GUI.Label (new Rect (10, 10, 200, 80), "Hello World!");
	}

	// GUIパターン10
	private void GUIpattern10() {
		// Assign the skin to be the one currently used.
		GUI.skin = mySkin;

		// Make a toggle. This will get the "button" style from the skin assigned to mySkin.
		toggle = GUI.Toggle (new Rect (10,10,150,20), toggle, "Skinned Button", "button");

		// Assign the currently skin to be Unity's default.
		GUI.skin = null;

		// Make a button. This will get the default "button" style from the built-in skin.
		GUI.Button (new Rect (10,35,150,20), "Built-in Button");
	}

	// GUIパターン11
	private void GUIpattern11() {
		// Make a group on the center of the screen
		GUI.BeginGroup (new Rect (Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 100));
		// All rectangles are now adjusted to the group. (0,0) is the topleft corner of the group.

		// We'll make a box so you can see where the group is on-screen.
		GUI.Box (new Rect (0,0,100,100), "Group is here");
		GUI.Button (new Rect (10,40,80,30), "Click me");

		// End the group we started above. This is very important to remember!
		GUI.EndGroup ();
	}

	// GUIパターン12
	private void GUIpattern12() {
		GUILayout.Button ("I am not inside an Area");
		GUILayout.BeginArea (new Rect (Screen.width / 2, Screen.height / 2, 300, 300));
		GUILayout.Button ("I am completely inside an Area");
		GUILayout.EndArea ();
	}

	// GUIパターン13
	private void GUIpattern13() {
		// Wrap everything in the designated GUI Area
		GUILayout.BeginArea (new Rect (0, 0, 200, 100));

		// Begin the singular Horizontal Group
		GUILayout.BeginHorizontal();

		// Place a Button normally
		if (GUILayout.RepeatButton ("Increase max\nSlider Value"))
		{
			maxSliderValue += 3.0f * Time.deltaTime;
		}

		// Arrange two more Controls vertically beside the Button
		GUILayout.BeginVertical();
		GUILayout.Box("Slider Value: " + Mathf.Round(sliderValue));
		sliderValue = GUILayout.HorizontalSlider (sliderValue, 0.0f, maxSliderValue);

		GUILayout.Button ("Button");

		// End the Groups and Area
		GUILayout.EndVertical();
		GUILayout.EndHorizontal();
		GUILayout.EndArea();
	}

	// GUIパターン14
	private void GUIpattern14() {
		mySlider = LabelSlider (new Rect (10, 100, 100, 20), mySlider, 5.0f, "Label text here");
	}

	private float LabelSlider (Rect screenRect, float sliderValue, float sliderMaxValue, string labelText) {
		GUI.Label (screenRect, labelText);

		// <- Push the Slider to the end of the Label
		screenRect.x += screenRect.width; 

		sliderValue = GUI.HorizontalSlider (screenRect, sliderValue, 0.0f, sliderMaxValue);
		return sliderValue;
	}

}
