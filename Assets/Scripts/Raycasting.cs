using UnityEngine;
using System.Collections;

public class Raycasting : MonoBehaviour {

	Camera mainCamera;

	[SerializeField] private float rotateX = 1f;
	[SerializeField] private float rotateY = 1f;


	// Use this for initialization
	void Start () {
		mainCamera = Camera.main;


	}
	
	// Update is called once per frame
	void Update () {

		CameraRotate ();

		RaycastHit hit;
		Ray ray = new Ray(mainCamera.transform.position, mainCamera.transform.forward);

		if (Physics.Raycast(ray, out hit)) {
			Transform objectHit = hit.transform;

			// Do something with the object that was hit by the raycast.
			Debug.Log ("Hit " + objectHit.gameObject);

		}


	}


	private void CameraRotate() {
		
		if (Input.GetKey(KeyCode.RightArrow)) {
			mainCamera.transform.Rotate(Vector3.up, rotateY);
		}
		if (Input.GetKey(KeyCode.LeftArrow)) {
			mainCamera.transform.Rotate(Vector3.up, -rotateY);
		}
		if (Input.GetKey(KeyCode.UpArrow)) {
			mainCamera.transform.Rotate(Vector3.right, -rotateX);
		}
		if (Input.GetKey(KeyCode.DownArrow)) {
			mainCamera.transform.Rotate(Vector3.right, rotateX);
		}

	}

}
