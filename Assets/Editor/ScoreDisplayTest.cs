using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq; //can change an array to a list


[TestFixture]
public class ScoreDisplayTest  {

	[Test]
	public void T00PassingTest() {
		Assert.AreEqual (1, 1);
	}

	public void T01Bowl23 () {
		int[] rolls = {2,3};
		string frames = "23";
		Assert.AreEqual (frames, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T02Bowl234561 () {
		int[] rolls = {2,3,4,5,6,1};
		string frames = "234561";
		Assert.AreEqual (frames, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	//Basic strike test
	[Test]
	public void T03BowlX1 () {
		int[] rolls = {10, 1};
		string frames = " X1";
		Assert.AreEqual (frames, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	//Basic spare test
	[Test]
	public void T04Bowl19 () {
		int[] rolls = {1, 9};
		string frames = "1/";
		Assert.AreEqual (frames, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T05SpareBonus2 () {
		int[] rolls = {1,2, 3,5, 5,5, 3,3, 7,1, 9,1, 6};
		string frames = "12355/33719/6";
		Assert.AreEqual (frames, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T06TestAllStrikes () {
		int[] rolls = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10,10,10};
		string frames = " X X X X X X X X XXXX";
		Assert.AreEqual (frames, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T07SpareInLastFrame () {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9,7};
		string frames = "1111111111111111111/7";
		Assert.AreEqual (frames, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T08StrikeAndSpareInLastFrame () {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,9,1};
		string frames = "111111111111111111X9/";
		Assert.AreEqual (frames, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}

	[Test]
	public void T09TestGutterGame () {
		int[] rolls = { 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0, 0,0};
		string frames = "00000000000000000000";
		Assert.AreEqual (frames, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}
	[Test]
	public void TG03GoldenCopyC2of3 () {
		int[] rolls = { 10, 10, 10, 10, 9,0, 10, 10, 10, 10, 10,9,1};
		string frames = " X X X X90 X X X XX9/";
		Assert.AreEqual (frames, ScoreDisplay.FormatRolls (rolls.ToList ()));
	}


}
