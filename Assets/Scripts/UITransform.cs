using UnityEngine;
using System.Collections;

public class UITransform : MonoBehaviour {

	public Camera _camera;

	public float distance = 0.0f;

	public float canvasWidth = 0.0f;
	public float canvasHeight = 0.0f;

	// Use this for initialization
	void Start () {
		if (_camera == null) {
			_camera = GameObject.FindGameObjectWithTag("Main Camera").GetComponent<Camera>();
		}

		CreateCanvasAroundCamaraForAngle (_camera, -5f, -5f, 0f);

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// カメラの正面方向から指定した角度の方向にオブジェクトを出現させる
	private void CreateCanvasAroundCamaraForAngle(Camera cam, float x, float y, float z) {
		// forwardに対して回転させたベクトルを求める
		var angleForward = Quaternion.Euler (x, y, z) * cam.transform.forward;
		Vector3 objPosition = cam.transform.position + angleForward * distance;

		ApearCanvas (objPosition, cam.transform.forward);
	}

	// Canvasを表示する
	private void ApearCanvas(Vector3 pos, Vector3 forward) {
		var _canvas = GameObject.Find("Canvas");
		_canvas.transform.position = pos;

		// 
		RectTransform rectTransform = _canvas.GetComponent<RectTransform> ();
		rectTransform.sizeDelta = new Vector2 (canvasWidth, canvasHeight);

		// 任意の方向に対して、そのベクトルに垂直になるように角度を調整する
		_canvas.transform.forward = forward;

	}
}
