﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Timeline;

public class LookAtPlayer : MonoBehaviour
{
	private RotateScript rotateScript;
	
	[SerializeField]
	private ActivateEyeball activateEyeball;
	
	public static Action<LookAtPlayer> OnEyeReset;

	// Use this for initialization
	void Start ()
	{
		rotateScript = GetComponent<RotateScript>();

		FinishLineReached.OnFinishLineReached += EnableRotateScript;
		PlayerCollisions.OnObstacleHit += DisableRotateScript;

		transform.position = Vector3.zero;

		transform.DOMoveY(0.2f, 0.5f);

	}

	private void OnDestroy()
	{

		FinishLineReached.OnFinishLineReached -= EnableRotateScript;
		PlayerCollisions.OnObstacleHit -= DisableRotateScript;
	}


	private void DisableRotateScript(PlayerCollisions sender)
	{
		rotateScript.enabled = false;
		transform.DOMove(Vector3.zero, 0.5f);
		transform.DORotate(Quaternion.identity.eulerAngles, 0.5f);
		Invoke("PlayCloseAnim", 0.45f);
		Destroy(gameObject, 0.5f);

	}

	private void PlayCloseAnim()
	{
		OnEyeReset(this);
	}

	private void EnableRotateScript(FinishLineReached sender)
	{
		rotateScript.enabled = true;
	}
	
}
