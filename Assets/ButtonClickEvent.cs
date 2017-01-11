using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;

public class ButtonClickEvent : MonoBehaviour {

	[SerializeField] Slider slider;
	[SerializeField] Button button;

	// Use this for initialization
	void Start () {
		slider.onValueChanged.AddListener (OnSlide);

		// button.onClick.AddListener (ShowLog);

		UnityAction onClickAction = ShowLog;
		button.onClick.AddListener (onClickAction);

		UnityAction onClickAction2 = () => Debug.Log ("Hello UnityAction 2");
		button.onClick.AddListener (onClickAction2);

		button.onClick.AddListener (() => Debug.Log ("Hello UnityAction 3"));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnSlide (float value)
	{
		Debug.Log (value);

		var screen = GameObject.Find ("Screen");
		var screenPosition = screen.transform.position;
		Vector3 pos = new Vector3 (screenPosition.x, screenPosition.y, value);
		screen.transform.position = pos;
	}

	void ShowLog ()
	{
		Debug.Log ("Hello UnityAction");
	}

}
