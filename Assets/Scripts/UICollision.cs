using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UICollision : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// 衝突判定
	private void OnCollisionEnter(Collision collision) {
		Debug.Log ("On Collision Enter!");
		// 衝突対象がCanvasの場合、色をランダムに変える
		var UIobj = collision.gameObject;
		UIobj.GetComponent<CanvasRenderer> ().SetColor(new Color (Random.value, Random.value, Random.value));
		Debug.Log (collision.contacts [0].point);
	}

	// トリガー判定
	private void OnTriggerEnter(Collider collider) {
		Debug.Log ("On Trigger Enter!");
		// 衝突対象がCanvasの場合、色をランダムに変える
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
