using UnityEngine;
using System.Collections;

public class CollisionObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	// 衝突判定
	private void OnCollisionEnter(Collision collision) {
		// 衝突したオブジェクトの色をランダムに変える
		var obj = collision.gameObject;
		obj.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value);

	}

	private void OnCollisionStay(Collision collision) {

		foreach (ContactPoint contact in collision.contacts) {
			Debug.Log (contact.thisCollider.name + " hit " + contact.otherCollider.name);
			// Debug.DrawRay(contact.point, contact.normal, Color.white);

			// Debug.Log ("Points colliding: " + collision.contacts.Length);
			// Debug.Log ("First point that collided: " + collision.contacts [0].point);
		}
	}

	private void OnCollisionExit(Collision collision) {
		
	}


	// トリガー判定
	private void OnTriggerEnter(Collider collider) {

		var obj = collider.gameObject;
		obj.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value);

	}

	private void OnTriggerStay(Collider collider) {

	}

	private void OnTriggerExit(Collider collider) {
		
		var obj = collider.gameObject;
		obj.GetComponent<Renderer> ().material.color = new Color (Random.value, Random.value, Random.value);

	}

}
