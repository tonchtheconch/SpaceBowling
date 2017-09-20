using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PinCounter : MonoBehaviour {
	private Text pinAmt;
	private GameManager gM;

	private bool ballExitSpace = false;
	private int lastStandingCount = -1;
	public int lastSettledCount = 10; 
	private float lastChangeTime = 0;

	// Use this for initialization
	void Start () {
		pinAmt = GameObject.Find ("Pins Standing").GetComponent<Text>();
		gM = GameObject.FindObjectOfType<GameManager> ();
	}

	// Update is called once per frame
	void Update () {
		pinAmt.text = CountStanding ().ToString ();
		if (ballExitSpace) {
			pinAmt.color = Color.red;
			CheckStanding ();
		}
	}

	public void Reset() {
		lastSettledCount = 10; 
	}

	public void PinsHaveSettled() {
		pinAmt.color = Color.green;
		lastStandingCount = -1;
		ballExitSpace = false;
		int pinsFallen = lastSettledCount - CountStanding ();

		lastSettledCount = CountStanding ();

		gM.Bowl (pinsFallen);
	}
		

	void CheckStanding() {
		int curStanding = CountStanding ();
	
		if (lastStandingCount != curStanding) {
			lastStandingCount = curStanding;
			lastChangeTime = Time.time;
			return;
		}

		if (Time.time - lastChangeTime >= 3) {
			PinsHaveSettled ();
		}
	}

	int CountStanding () {
		int standing = 0;
		foreach (Pin p in GameObject.FindObjectsOfType<Pin> ()) {
			if (p.isStanding ()) {
				standing++;
			}
		}
		return standing;
	}

	void OnTriggerExit(Collider col) {
		if (col.GetComponent<Ball>()) {
			ballExitSpace = true;
		}
	}
}
