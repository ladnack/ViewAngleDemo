using UnityEngine;
using System.Collections;

public class AnalyzeMesh : MonoBehaviour {

	// Use this for initialization
	void Start () {

		Mesh mesh = gameObject.GetComponent<MeshFilter>().mesh;

		for(int i = 0; i < mesh.vertices.Length; i++)
		{
			print("vertices[" + i + "] : " + mesh.vertices[i]);
		}

		for(int i = 0; i < mesh.uv.Length; i++)
		{
			print("uv[" + i + "] : " + mesh.uv[i]);
		}

		for(int i = 0; i < mesh.triangles.Length; i++)
		{
			print("triangles[" + i + "] : " + mesh.triangles[i]);
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
