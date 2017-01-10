﻿using UnityEngine;
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

	public class CubeVertices
	{
		// Cubeの頂点を指定するためのenum
		public enum vertices
		{
			A, B, C, D, E, F, G, H
		};

		public struct IndexOfVertex {
			public int index1, index2, index3;

			public IndexOfVertex(int index1, int index2, int index3) {
				this.index1 = index1;
				this.index2 = index2;
				this.index3 = index3;
			}
		}

		public static IndexOfVertex[] indexData = {
			new IndexOfVertex(3, 9, 17),
			new IndexOfVertex(2, 8, 22),
			new IndexOfVertex(5, 11, 18),
			new IndexOfVertex(4, 10, 21),
			new IndexOfVertex(1, 14, 16),
			new IndexOfVertex(0, 13, 23),
			new IndexOfVertex(7, 15, 19),
			new IndexOfVertex(6, 12, 20)
		};

		public static IndexOfVertex GetIndexOf(vertices vert) {
			return indexData[(int)vert];
		}

		public static int[] GetIndexArrayOf(vertices vert) {
			var data = indexData[(int)vert];
			int[] array = {
				data.index1, data.index2, data.index3
			};
			return array;
		}

		public struct VerticesOfSurface {
			public vertices vert1, vert2, vert3, vert4;

			public VerticesOfSurface(vertices vert1, vertices vert2, vertices vert3, vertices vert4) {
				this.vert1 = vert1;
				this.vert2 = vert2;
				this.vert3 = vert3;
				this.vert4 = vert4;
			}
		}

		public static VerticesOfSurface[] vertexData = {
			new VerticesOfSurface(vertices.A, vertices.B, vertices.C, vertices.D),
			new VerticesOfSurface(vertices.E, vertices.F, vertices.G, vertices.H),
			new VerticesOfSurface(vertices.B, vertices.D, vertices.F, vertices.H),
			new VerticesOfSurface(vertices.A, vertices.C, vertices.E, vertices.G),
			new VerticesOfSurface(vertices.A, vertices.B, vertices.E, vertices.F),
			new VerticesOfSurface(vertices.C, vertices.D, vertices.G, vertices.H)
		};

		// Cubeの面を指定するためのenum
		public enum surface {
			// 上下左右前後を表す
			upward, downward, leftSide, rightSide, forward, backward
		};

		public static VerticesOfSurface GetVerticesOf(surface surf) {
			return vertexData[(int)surf];
		}

		public static vertices[] GetVerticesArrayOf(surface surf) {
			var data = vertexData[(int)surf];
			vertices[] array = {
				data.vert1, data.vert2, data.vert3, data.vert4
			};
			return array;
		}

	}


	// Use this for initialization
	void Start () {
		if (eyes != null) {
			
			// 初期位置を設定する
			eyes.transform.position = new Vector3(0f, 0f, 0f);
			// Debug.Log ("eyes.transform.position: " + eyes.transform.position);

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

			/*
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
			*/

			var point = PointCos (eyes.transform.position, eyes.transform.forward, distance, 15, Direction.upward);

			// 頂点とpointの並行直線距離を求める
			var d = Vector3.Distance(screen.transform.position, point);
			var length = d - screen.transform.localScale.y / 2;
			// Debug.Log ("length: " + length);


			extendCubeTo (screen, CubeVertices.surface.upward, length);
			extendCubeTo (screen, CubeVertices.surface.downward, length);
			extendCubeTo (screen, CubeVertices.surface.leftSide, length);
			extendCubeTo (screen, CubeVertices.surface.rightSide, length);
			//extendCubeTo (screen, CubeVertices.surface.forward, length);
			//extendCubeTo (screen, CubeVertices.surface.backward, length);

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

	private Vector3 PointCos(Vector3 originA, Vector3 vectAC, float distanceAC, float degree, Direction direction) {
		// 三角形ABCを考える
		// A、Cがわかっている時、角ACBが直角をなすように角BAC＝θに従って、点Bの位置を求める

		// degreeは0〜90に設定する
		if (degree <= 0 || 90 <= degree) {
			return Vector3.zero;
		}

		// 距離ABをcosθを利用して求める
		float distanceAB = distanceAC / Mathf.Cos (degree * Mathf.Deg2Rad);

		Vector3 vectAB = Vector3.zero;

		// ABベクトルを求める
		switch (direction)
		{
		case Direction.upward:
			vectAB = Quaternion.Euler (-degree, 0, 0) * vectAC;
			break;
		case Direction.downward:
			vectAB = Quaternion.Euler (degree, 0, 0) * vectAC;
			break;
		case Direction.leftSide:
			vectAB = Quaternion.Euler (0, degree, 0) * vectAC;
			break;
		case Direction.rightSide:
			vectAB = Quaternion.Euler (0, -degree, 0) * vectAC;
			break;
		default:
			break;
		}

		// 点Bを求める
		var pointB = originA + vectAB * distanceAB;

		return pointB;
	}

	private enum Direction {
		// 上下左右を表す
		upward, downward, leftSide, rightSide
	}

	private void extendCubeTo(GameObject cube, CubeVertices.surface surface, float length) {
		MeshFilter _meshFilter = cube.GetComponent<MeshFilter>();
		Vector3[] _vertices = new Vector3[24];
		_vertices = _meshFilter.mesh.vertices;

		// Cube面の４頂点を引伸ばす

		foreach (CubeVertices.vertices vert in CubeVertices.GetVerticesArrayOf(surface)) {
			
			foreach (int index in CubeVertices.GetIndexArrayOf (vert)) {
				switch (surface)
				{
				case CubeVertices.surface.upward:
					_vertices [index].y = length;
					break;
				case CubeVertices.surface.downward:
					_vertices [index].y = -length;
					break;
				case CubeVertices.surface.leftSide:
					_vertices [index].x = length;
					break;
				case CubeVertices.surface.rightSide:
					_vertices [index].x = -length;
					break;
				case CubeVertices.surface.forward:
					_vertices [index].z = length;
					break;
				case CubeVertices.surface.backward:
					_vertices [index].z = -length;
					break;
				default:
					break;
				}
			}
		}

		_meshFilter.mesh.vertices = _vertices;
		_meshFilter.mesh.RecalculateBounds();
	}

}
