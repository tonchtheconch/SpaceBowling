using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PinSetter : MonoBehaviour {
	public float distanceToRaise = 60f;
	public GameObject PinSet;

	private Animator aN;
	private PinCounter pc;
	private float distRaised = 0;
	private bool raising = false;

	// Use this for initialization
	void Start () {
		pc = GameObject.FindObjectOfType<PinCounter> ();
		aN = GetComponent<Animator> ();
	}

	void Update() {
		if (raising) {
			RaisePins ();
		}
	}

	public void RaisePins() {
		Debug.Log ("Raising");
		if (distRaised == 60) {
			raising = false;
			distRaised = 0;
		} else {
			distRaised++;
		}
			
		foreach (Pin p in GameObject.FindObjectsOfType<Pin> ()) {
			if (p.isStanding ()) {
				p.transform.Translate (Vector3.up);
				p.transform.rotation = Quaternion.identity;
				Rigidbody r = p.GetComponent<Rigidbody>();
				r.useGravity = false;
				r.angularVelocity = Vector3.zero;
			}
		}
	}

	public void LowerPins() {
		Debug.Log ("Raised");
		foreach (Pin p in GameObject.FindObjectsOfType<Pin> ()) {
			if (p.isStanding ()) {
				Rigidbody r = p.GetComponent<Rigidbody>();
				p.transform.rotation = Quaternion.identity;
				//p.transform.Translate (new Vector3 (0, 0, 0));
				r.useGravity = true;
			}
		}
	}

	public void ResetPins() {
		Instantiate (PinSet, new Vector3(0, 20, 1829), Quaternion.identity);
	}
		


	public void ActionExcecutor (ActionMaster.Action act) {
		if (act == ActionMaster.Action.Tidy) {
			aN.SetTrigger ("TidyTrigger");
			raising = true;
		} else if (act == ActionMaster.Action.EndTurn || act == ActionMaster.Action.Reset) {
			aN.SetTrigger ("ResetTrigger");
			pc.Reset ();
		} else if (act == ActionMaster.Action.EndGame) {

		}
	}


	void OnTriggerExit (Collider col) {
		if (col.gameObject.GetComponentInParent<Pin> ()) {
			Destroy (col.gameObject.transform.parent.gameObject);
		}
	}

}
