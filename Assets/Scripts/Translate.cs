using UnityEngine;
using System.Collections;

public class Translate : MonoBehaviour {

	public GameObject obj;
	private float rate = 0.1f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		// オブジェクトをZ方向に前進させる
		if (Input.GetKey (KeyCode.UpArrow)) {
			obj.transform.position += new Vector3 (0f, 0f, rate);
		}

		// オブジェクトをZ方向に後退させる
		if (Input.GetKey (KeyCode.DownArrow)) {
			obj.transform.position -= new Vector3 (0f, 0f, rate);
		}
	}
}
