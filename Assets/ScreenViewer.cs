using UnityEngine;
using System.Collections;

public class ScreenViewer : MonoBehaviour {

	public Camera eyes;
	public float distance = 1.0f;

	public Vdata Klog;

	[System.Serializable]//表示
	public class Vdata//[Vector3]型のステータス一覧
	{
		public Vector3 A;//奥右上
		public Vector3 B;//奥左上
		public Vector3 C;//手前右上
		public Vector3 D;//手前左上
		public Vector3 E;//奥右下
		public Vector3 F;//奥左下
		public Vector3 G;//手前右下
		public Vector3 H;//手前左下
	}

	private GameObject screen;

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

			// カメラ正面にオブジェクトを配置
			CreateObjectAroundCamaraForAngle (eyes, 0, 0, 0);

			/*
			// カメラ正面上下にオブジェクトを配置
			CreateObjectAroundCamaraForAngle (eyes, 30, 0, 0);
			CreateObjectAroundCamaraForAngle (eyes, -30, 0, 0);

			// カメラ正面左右にオブジェクトを配置
			CreateObjectAroundCamaraForAngle (eyes, 0, 30, 0);
			CreateObjectAroundCamaraForAngle (eyes, 0, -30, 0);
			*/




		}
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown (KeyCode.Space)) {
			Debug.Log ("Space key was pressed.");
			MeshFilter _meshFilter = screen.GetComponent<MeshFilter>();
			_meshFilter.mesh.RecalculateBounds();
		}
	}


	// カメラの正面方向から指定した角度の方向にオブジェクトを出現させる
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
		// cube.transform.localScale = new Vector3 (1, 1, 0);

		this.screen = cube;

		// CubeのMeshFilterを取得
		MeshFilter _meshFilter = cube.GetComponent<MeshFilter>();
		// vertices（頂点）を取得
		Vector3[] _vertices = new Vector3[24];
		// Debug.Log (_vertices.Length);	// 24

		for (int i = 0; i < _meshFilter.mesh.vertices.Length; i++) {
			_vertices [i] = _meshFilter.mesh.vertices [i];
		}

		Vector3 newVertex = _vertices [2] * 2; 

		_vertices [2] = newVertex;
		_vertices [8] = newVertex;
		_vertices [22] = newVertex;

		foreach (Vector3 vertex in _vertices) {
			Debug.Log (vertex);
		}

		_meshFilter.mesh.vertices = _vertices;
		_meshFilter.mesh.RecalculateBounds();
	}




}
