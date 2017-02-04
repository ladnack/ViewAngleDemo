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

		// 距離を設定し、それに対応してAutoSizingする（拡張メソッド）
		canvas.AutoSizingFor(10.0f);
		distance = Vector3.Distance (canvas.transform.position, mainCamera.transform.position);
		scale = canvas.transform.localScale.x;

		Debug.Log (distance + ", " + scale); 

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

// Canvasクラスの機能拡張
static class CanvasExtensions {

	public static void AutoSizingFor(this Canvas canvas, float distance) {
		// Main Cameraからの距離をdistanceに変更（Cameraのpositionが（0, 0, 0）の時）
		canvas.transform.Translate(0f, 0f, distance - canvas.transform.position.z);
		// distanceに基づいて一定の比率でscaleを調整
		var scale = distance / canvas.planeDistance * canvas.transform.localScale.x;
		canvas.transform.localScale = new Vector3 (scale, scale, scale);

	}

}
