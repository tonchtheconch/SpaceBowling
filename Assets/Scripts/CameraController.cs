using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {
	public Ball b;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = b.transform.position - transform.position;
		print (1802 - offset.z);

	}
	
	// Update is called once per frame
	void Update () {
		//change to 1829 when we can smash through the pins or not
		if (b.transform.position.z <= 1829f) {
			transform.position = b.transform.position - offset;
		}

	}
}
