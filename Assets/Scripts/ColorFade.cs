using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ColorFade : MonoBehaviour {

	// private Renderer _renderer;
	private Button _button;
	private float alpha;

	// Use this for initialization
	void Start () {
		// _renderer = GetComponent<Renderer> ();
		_button = GetComponent<Button> ();

		/*
		if (_renderer == null) {
			Debug.Log ("Not find Renderer.");
			return;
		}
		*/

		if (_button == null) {
			Debug.Log ("Not find Button.");
			return;
		}

		// alpha = _renderer.material.color.a;
		alpha = _button.colors.normalColor.a;

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("f")) {
			Debug.Log ("Push Key F.");
			/*
			if (_renderer != null) {
				StartCoroutine ("Fade");
			}
			*/

			if (_button != null) {
				StartCoroutine ("Fade");
			}
		}
	}

	// コルーチンを用いてフェードさせる
	IEnumerator Fade() {
		for (float f = 1f; f >= 0; f -= 0.01f) {
			/*
			Color _color = _renderer.material.color;
			_color.a = f;
			_renderer.material.color = _color;
			*/

			Color _color = _button.colors.normalColor;
			_color.a = f;
			alpha = _color.a;
			ColorBlock colors = _button.colors;
			colors.normalColor = _color;
			_button.colors = colors;
			Debug.Log ("Update alpha = " + _color.a);
			yield return null;
		}
	}

	void OnGUI() {
		GUI.Box (new Rect (0, 0, 100, 50), "alpha = " + alpha);
	}


}
