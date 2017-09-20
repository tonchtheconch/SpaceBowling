using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private Rigidbody rb;
	private AudioSource au;
	private bool launched = false;
	private Vector3 origPos;
	//public float speed;
	public Vector3 velocity;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		au = GetComponent<AudioSource> ();
		rb.useGravity = false;
		origPos = transform.position;
	}

	public void Launch(Vector3 v) {
		rb.useGravity = true;
		rb.velocity = v;
		au.Play ();
		launched = true;
	}

	public bool isLaunched() {
		return launched;
	}

	public void reset() {
		transform.position = origPos;
		transform.rotation = Quaternion.identity;
		rb.velocity = Vector3.zero;
		rb.angularVelocity = Vector3.zero;
		rb.useGravity = false;
		launched = false;
	}

		
}
