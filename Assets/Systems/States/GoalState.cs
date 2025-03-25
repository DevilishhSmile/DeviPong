﻿using UnityEngine;
using System.Collections;
using DG.Tweening;

public class GoalState : _StatesBase
{
	#region implemented abstract members of _StatesBase

	public override void OnActivate ()
	{		
		Debug.Log ("<color=green>Goal State</color> OnActive");	
		Managers.PowUps.DestroyPowerups ();
		Managers.PowUps.canSpawnPowerup = false;
		Managers.Match.Reset();
		GoalCelebration ();
	}

	public override void OnDeactivate ()
	{
		Debug.Log ("<color=red>Goal State</color> OnDeactivate");
	}

	public override void OnUpdate ()
	{
		Debug.Log ("<color=yellow>Goal State</color> OnUpdate");
	}

	#endregion

	public void GoalCelebration()
	{
		// DOTween.To(
		// 	() => , x => Managers.UI.inGameUI.info.color = x, new Color (Managers.UI.inGameUI.infoInitColor.r, Managers.UI.inGameUI.infoInitColor.g, Managers.UI.inGameUI.infoInitColor.b, 0), 0.8f)
		// 	.SetLoops(3)
		// 	.OnComplete (() => { Managers.Game.SetState(typeof(KickOffState)); });	
	}


}
