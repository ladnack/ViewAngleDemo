using UnityEngine;
using System.Collections;

public class CollisionObject : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	private void OnCollisionEnter(Collision collision) {
		Debug.Log ("OnCollisionEnter!");
	}

	private void OnCollisionStay(Collision collision) {
		// Debug.Log ("OnCollisionStay!");

		foreach (ContactPoint contact in collision.contacts) {
			print(contact.thisCollider.name + " hit " + contact.otherCollider.name);
			Debug.DrawRay(contact.point, contact.normal, Color.white);

			print("Points colliding: " + collision.contacts.Length);
			print("First point that collided: " + collision.contacts[0].point);

		}
	}

}
