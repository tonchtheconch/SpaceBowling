using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	private List<int> pinFalls = new List<int>();
	private PinSetter ps;
	private Ball b;
	private ScoreDisplay sD; 

	// Use this for initialization
	void Start () {
		ps = GameObject.FindObjectOfType<PinSetter> ();
		b = GameObject.FindObjectOfType<Ball> ();
		sD = GameObject.FindObjectOfType<ScoreDisplay> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Bowl(int pinFall) {
		pinFalls.Add (pinFall);
		ps.ActionExcecutor (ActionMaster.NextAction (pinFalls));
		try {
			sD.FillRolls (pinFalls);
			sD.FillFrames (ScoreMaster.ScoreCumulative(pinFalls));
		} catch {
			Debug.LogWarning ("FillRollCard failed");
		}
		b.reset ();

		
	}
}
