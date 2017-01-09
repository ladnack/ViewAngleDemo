using UnityEngine;
using System.Collections;

public class ScreenViewer : MonoBehaviour {

	public Camera eyes;
	public float distance = 1.0f;

	// Use this for initialization
	void Start () {
		if (eyes != null) {
			
			// 初期位置を設定する
			eyes.transform.position = new Vector3(0f, 0f, 0f);
			Debug.Log ("eyes.transform.position: " + eyes.transform.position);

			/*
			// カメラ正面方向を取得
			Vector3 forward = eyes.transform.forward;
			Debug.Log ("eyes.transform.forward: " + eyes.transform.forward);

			// カメラ位置から任意の距離の点を求める
			var newForward = forward * distance;
			Vector3 cubePosition = eyes.transform.position + newForward;
			Debug.Log ("cubePosition: " + cubePosition);

			// オブジェクトを出現させる
			ApearCube (cubePosition);

			// ベクトルの回転
			// forwardをX軸周りに30度だけ回転させたベクトルを求める
			var angleForward = Quaternion.Euler (-30f, 0f, 0f) * forward;  
			Debug.Log ("angleForward:" + angleForward);

			// カメラ位置から任意の距離の点を求める
			Vector3 cube2Position = eyes.transform.position + angleForward * distance;
			Debug.Log ("cube2Position: " + cube2Position);

			// 同様にオブジェクトを出現させる
			ApearCube (cube2Position);
			*/

			CreateObjectAroundCamaraForAngle (eyes, 0, 0, 0);
			CreateObjectAroundCamaraForAngle (eyes, 30, 0, 0);
			CreateObjectAroundCamaraForAngle (eyes, -30, 0, 0);

		}
	}
	
	// Update is called once per frame
	void Update () {


	}

	private void CreateObjectAroundCamaraForAngle(Camera cam, float x, float y, float z) {
		// forwardに対して回転させたベクトルを求める
		var angleForward = Quaternion.Euler (x, y, z) * cam.transform.forward;
		Vector3 objPosition = cam.transform.position + angleForward * distance;
		ApearCube (objPosition);
	}

	// Cubeを生成する
	private void ApearCube(Vector3 pos) {
		var cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.position = pos;
	}




}
