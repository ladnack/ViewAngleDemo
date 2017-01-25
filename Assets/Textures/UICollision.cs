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

		// 衝突したGameObjectを取得
		var UIobj = collision.gameObject;
		// 衝突対象の色をランダムに変更する
		ChangeObjectColorRandom(UIobj);


		Debug.Log (collision.contacts [0].point);
	}

	// トリガー判定
	private void OnTriggerEnter(Collider collider) {
		Debug.Log ("On Trigger Enter!");

		// 接触したGameObjectを取得
		var UIobj = collider.gameObject;
		// トリガー対象の色をランダムに変更する
		ChangeObjectColorRandom(UIobj);

	}

	private void OnTriggerStay(Collider collider) {

	}

	private void OnTriggerExit(Collider collider) {

		// 接触したGameObjectを取得
		var UIobj = collider.gameObject;
		// トリガー対象の色をランダムに変更する
		ChangeObjectColorRandom(UIobj);

	}

	// GameObjectの色をランダムに変更する
	private void ChangeObjectColorRandom(GameObject obj) {
		// objがCanvasRendererを持っていれば、objはCanvasとする
		var canvasRenderer = obj.GetComponent<CanvasRenderer>();

		if (canvasRenderer != null) {
			// 衝突対象がCanvasの場合
			obj.GetComponent<CanvasRenderer> ().SetColor (new Color (Random.value, Random.value, Random.value));
		} else {
			// 衝突対象がCanvas以外のGameObjectの場合
			obj.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value);
		}
	}


}
