using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pin : MonoBehaviour {

	public float standingThreshold;

	public bool isStanding() {
		Vector3 rotationInEuler = transform.rotation.eulerAngles;

		return Mathf.Abs(Mathf.DeltaAngle(rotationInEuler.x,0)) < standingThreshold 
			&& Mathf.Abs(Mathf.DeltaAngle(rotationInEuler.z,0)) < standingThreshold;
	}
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}
}
