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


			// カメラからScreenまでの距離を求める（distance）

			// 任意の角度に回転させた方向とScreenの延長が織り成す点までの距離を求める
			float deg = 30.0f;
			float distance2 = distance / Mathf.Cos (deg * Mathf.Deg2Rad);
			Debug.Log ("distance: " + distance);
			Debug.Log ("distance2: " + distance2);

			// forwardに対して回転させたベクトルを求める
			var angleForward = Quaternion.Euler (-deg, 0, 0) * eyes.transform.forward;

			// Screenの端点となる点を求める
			Vector3 firstPoint = eyes.transform.position;
			var point = firstPoint + angleForward * distance2;
			Debug.Log ("point: " + point);

			// ApearCube (point);


			// 頂点とpointの並行直線距離を求める
			var d = Vector3.Distance(screen.transform.position, point);
			var length = d - screen.transform.localScale.y / 2;
			Debug.Log ("length: " + length);

			MeshFilter _meshFilter = screen.GetComponent<MeshFilter>();
			Vector3[] _vertices = new Vector3[24];
			_vertices = _meshFilter.mesh.vertices;

			// Screen上部４頂点を引伸ばす
			// 頂点A
			_vertices [3].y += length;
			_vertices [9].y += length;
			_vertices [17].y += length;

			// 頂点B
			_vertices [2].y += length;
			_vertices [8].y += length;
			_vertices [22].y += length;

			// 頂点C
			_vertices [5].y += length;
			_vertices [11].y += length;
			_vertices [18].y += length;

			// 頂点D
			_vertices [4].y += length;
			_vertices [10].y += length;
			_vertices [21].y += length;

			_meshFilter.mesh.vertices = _vertices;
			_meshFilter.mesh.RecalculateBounds();


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

		/*
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
			// Debug.Log (vertex);
		}

		foreach (int triangle in _meshFilter.mesh.triangles) {
			// Debug.Log ("triangles: " + triangle);
		}

		_meshFilter.mesh.vertices = _vertices;
		_meshFilter.mesh.RecalculateBounds();
		*/
	}



}
