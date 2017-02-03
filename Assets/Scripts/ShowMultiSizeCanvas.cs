using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ShowMultiSizeCanvas : MonoBehaviour {

	public Camera mainCamera;

	// Canvasのscale
	private float scale;
	// CanvasとCameraの距離
	private float distance;


	// Use this for initialization
	void Start () {

		// Cameraがセットされていなかったら、Main Cameraを探す
		if (mainCamera == null) {
			Debug.Log ("This mainCamera is null.");
			mainCamera = GameObject.Find ("Main Camera").GetComponent<Camera> ();
		}

		Canvas canvas = CreateCanvasObject ().GetComponent<Canvas> ();
		// CanvasをMainCamera正面に配置
		canvas.renderMode = RenderMode.ScreenSpaceCamera;
		canvas.worldCamera = mainCamera;
		// Canvasのsizeを調整
		//canvas.planeDistance = 10.0f;
		canvas.renderMode = RenderMode.WorldSpace;

		// 距離を設定し、それに対応してAutoSizingする
		distance = 10.0f;
		scale = distance / canvas.planeDistance * canvas.transform.localScale.x;

		// Canvasの位置を動かす
		canvas.transform.Translate(0f, 0f, distance - canvas.transform.position.z);
		canvas.transform.localScale = new Vector3 (scale, scale, scale);


	}


	// Update is called once per frame
	void Update () {
		
	}


	// Canvasを生成
	private GameObject CreateCanvasObject() {
		// デフォルトの設定
		var _canvas = new GameObject ("Canvas");
		_canvas.AddComponent<RectTransform> ();
		_canvas.AddComponent<Canvas> ();
		_canvas.AddComponent<CanvasRenderer> ();
		_canvas.AddComponent<CanvasScaler> ();
		_canvas.AddComponent<GraphicRaycaster> ();

		// 背景色をつける
		_canvas.AddComponent<RawImage> ();
		// RawImage.colorはいじらず、CanvasRendererで色を変更（RawImageがないと色がつかない？）
		float alpha = 0.6f;
		_canvas.GetComponent<CanvasRenderer> ().SetColor (new Color (Random.value, Random.value, Random.value, alpha));

		return _canvas;
	}



}
