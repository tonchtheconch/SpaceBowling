using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text[] rollTexts, frameTexts;

	public void FillRolls (List<int> rolls) {
		string rollDisplay = FormatRolls (rolls);
		for (int i = 0; i < rollDisplay.Length; i++) {
			rollTexts [i].text = rollDisplay [i].ToString ();
		}
	}

	public void FillFrames (List<int> frames) {
		for (int i = 0; i < frames.Count; i++) {
			frameTexts [i].text = frames [i].ToString ();
		}
	}

	public static string FormatRolls (List<int> rolls) {
		string output = "";
		for (int i = 0; i < rolls.Count; i++) {
			//if we're in the final frame and strike
			if (output.Length >= 18 && rolls [i] == 10) {
				output += "X";
			} else if (output.Length % 2 == 0 && rolls [i] == 10) {
				output += " ";
				output += "X";
			} else if (output.Length % 2 == 1 && rolls [i] + rolls [i - 1] == 10 
				|| output.Length == 20 && rolls [i] + rolls [i - 1] == 10) {
				output += "/";
			} else if (rolls [i] <= 9) {
				output += rolls [i].ToString ();
			}
			Debug.Log (rolls [i]);
			Debug.Log (output);
		}
		return output;
	}
}
