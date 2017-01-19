using UnityEngine;
using System.Collections;

public class UICollision : MonoBehaviour {

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

	}

	// トリガー判定
	private void OnTriggerEnter(Collider collider) {
		Debug.Log ("On Trigger Enter!");
		var UIobj = collider.gameObject;
		UIobj.GetComponent<CanvasRenderer> ().SetColor(new Color (Random.value, Random.value, Random.value));
			
	}

	private void OnTriggerStay(Collider collider) {

	}

	private void OnTriggerExit(Collider collider) {

		var UIobj = collider.gameObject;
		UIobj.GetComponent<CanvasRenderer> ().SetColor(new Color (Random.value, Random.value, Random.value));

	}


}
