using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragLaunch : MonoBehaviour {

	private Ball b;
	private Vector3 startPos;
	private float startTime;

	// Use this for initialization
	void Start () {
		b = GetComponent<Ball> ();
	}

	public void MoveAmount(float xNudge) {
		if (b.isLaunched () == false && transform.position.x + xNudge >= -41.65 && transform.position.x + xNudge <= 41.65) {
			transform.Translate (new Vector3 (xNudge, 0, 0));
		}

	}
		

	public void DragStart() {
		startPos = Input.mousePosition;
		startTime = Time.time;
	}

	public void DragEnd() {
		float dragDuration = Time.time - startTime;
		float xDir = Input.mousePosition.x - startPos.x;
		float zSpeed = (Input.mousePosition.y - startPos.y) / dragDuration; // a faster movement in y = faster z speed

		if (!b.isLaunched ()) {
			b.Launch (new Vector3(xDir, 0, zSpeed));
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
