using UnityEngine;
using System.Collections;

public class GetAngle : MonoBehaviour {

	public GameObject _gameObject;
	public Camera _camera;

	// Use this for initialization
	void Start () {
		if (_gameObject == null) {
			_gameObject = new GameObject ();
		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Space key was pressed!");

			// 視線の向き（頭部の向き）を求める
			Vector3 lineOfSight = _camera.transform.forward;
			Debug.Log("lineOfSight: " + lineOfSight);

			// Cameraからコントローラーまでのベクトルを取得する
			Vector3 objectFromCamera = _gameObject.transform.position - _camera.transform.position;
			Debug.Log("gameObject.position: " + _gameObject.transform.position);
			Debug.Log("objectFromCamera.position: " + _camera.transform.position);

			// 視線方向に対するコントローラー角度を求める
			var angle = Vector3.Angle(lineOfSight, objectFromCamera);
			Debug.Log("angle: " + angle);
		}


	}
}
