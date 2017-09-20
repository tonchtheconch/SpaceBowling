using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionMasterOld {

	public enum Action {Tidy, Reset, EndTurn, EndGame};

	private int bowl = 1;
	private int[] Scores = new int[21];

	public static Action NextAction (List<int> pinFalls) {
		ActionMasterOld am = new ActionMasterOld ();
		ActionMasterOld.Action curAction = new Action();

		foreach (int pins in pinFalls) {
			curAction = am.Bowl (pins);
		}

		return curAction;
	}

	private Action Bowl (int pins) {
		if (pins < 0 || pins > 10) {
			throw new UnityException ("Invalid pins");
		}

		Scores [bowl - 1] = pins;

		if (bowl == 21 || (!Bowl21Given() && bowl == 20)) {
			return Action.EndGame;
		}

		if (bowl >= 19 && Bowl21Given()) {
			bowl++;
			if (bowl - 1 == 20 && pins != 10 && Scores[19 - 1] == 10) {
				
				return Action.Tidy;
			}
			return Action.Reset;
		}
			

		if (bowl % 2 == 1) {
			if (pins == 10) {
				bowl += 2;
				return Action.EndTurn;
			}
			bowl++;
			return Action.Tidy;
		} else {
			bowl++;
			return Action.EndTurn;
		}
			
		throw new UnityException ("Not sure what action to return here");
	}

	bool Bowl21Given() {
		return (Scores[19 - 1] + Scores[20-1] >= 10);
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
