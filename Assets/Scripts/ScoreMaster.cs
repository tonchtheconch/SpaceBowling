using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScoreMaster {

	public static List<int> ScoreCumulative (List<int> rolls) {
		List<int> culScore = new List<int> ();

		int totalSoFar = 0;
		foreach (int frame in ScoreFrames(rolls)) {
			totalSoFar += frame;
			culScore.Add (totalSoFar);
		}

		return culScore;
	}

	public static List<int> ScoreFrames (List<int> rolls) {
		List<int> frameScores = new List<int> ();

		int totalSoFar = 0;
		int bowls = 0;
		for (int i = 0; i < rolls.Count; i++) {
			// 10 frame will be finished at this point (dont count an extra frame here)
			if (bowls == 20) {
				break;
			}
			// first throw cases
			// if strike on first throw of frame
			if (bowls % 2 == 0 && rolls [i] == 10) {
				// gaurd against accesing invalid memory with the private method below
				if (i + 2 >= rolls.Count) {
					break;
				}
				frameScores.Add (strikeScore (rolls, i + 1) + 10);
				totalSoFar = 0;
				bowls ++;
				// if not then...
			} else if (bowls % 2 == 0) {
				totalSoFar = rolls [i];
			// 2nd throw conditions
			} else {
				totalSoFar += rolls [i];
				if (rolls [i] + rolls [i - 1] == 10) {
					// gaurd if there is no way to calculate spare yet
					if (i + 1 == rolls.Count) {
						break;
					}
					totalSoFar += rolls [i + 1];
				}
				frameScores.Add (totalSoFar);
				totalSoFar = 0;
					
			}
				
			bowls ++;
		}

		return frameScores;
	}

	//assumes you already gaurded against accessing past the list length
	private static int strikeScore(List<int> rolls, int startPos) {
		int score = 0;
		for (int j = 0; j < 2; j++) {
			score += rolls [startPos];
			startPos++;
		}
		return score;
	}
}

