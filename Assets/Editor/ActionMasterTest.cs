using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using System.Linq; //can change an array to a list


[TestFixture]
public class ActionMasterTest {

	private List<int> pinFalls = new List<int>();
	private ActionMaster.Action endTurn = ActionMaster.Action.EndTurn;
	private ActionMaster.Action tidy = ActionMaster.Action.Tidy;
	private ActionMaster.Action reset = ActionMaster.Action.Reset;
	private ActionMaster.Action endGame = ActionMaster.Action.EndGame;


	[Test]
	public void T00PassingTest() {
		Assert.AreEqual (1, 1);
	}

	[Test]
	public void T01FirstStrikeREndTurn() {
		pinFalls.Add (10);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(pinFalls));
	}

	[Test]
	public void T02Bowl8RTidy() {
		pinFalls.Add (8);
		Assert.AreEqual (tidy, ActionMaster.NextAction(pinFalls));
	}

	[Test] 
	public void T03Bowl2Spare8REndTurn() {
		List<int> pf = new List<int>();
		pf.Add (2);
		Assert.AreEqual (tidy, ActionMaster.NextAction(pf));
		pf.Add (8);
		Assert.AreEqual (endTurn, ActionMaster.NextAction(pf));
	}

	[Test] 
	public void T04StrikeAt19Reset() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10 };
		Assert.AreEqual (reset, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test] 
	public void T05SpareAt20Reset() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1, 9 };
		Assert.AreEqual (reset, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test] 
	public void T06EndAt20() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1, 2 };
		Assert.AreEqual (endGame, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test] 
	public void T07EndAt21() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,9, 10};
		Assert.AreEqual (endGame, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test] 
	public void T07NStrikeAt20RTidy() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 1};
		Assert.AreEqual (tidy, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test] 
	public void T08NStrikeAt20RTidy() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10, 0};
		Assert.AreEqual (tidy, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test] 
	public void T09Bowl0Spare10REndTurn() {
		int[] rolls = { 0,10, 0};
		Assert.AreEqual (tidy, ActionMaster.NextAction (rolls.ToList()));
	}

	[Test] 
	public void T10EndAt21() {
		int[] rolls = { 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 1,1, 10,10, 10};
		Assert.AreEqual (endGame, ActionMaster.NextAction (rolls.ToList()));
	}





}