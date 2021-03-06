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

	private bool shouldLookAtPlayer;

	private GameObject player;
	
	// Use this for initialization
	private void Awake()
	{
		player = GameObject.FindGameObjectWithTag("Player");
	}

	void Start ()
	{
		
		
		rotateScript = GetComponent<RotateScript>();

		FinishLineReached.OnFinishLineReached += EnableRotateScript;
		PlayerCollisions.OnObstacleHit += DisableRotateScript;


		transform.position = Vector3.zero;

		//transform.DOMoveY(0.2f, 0.5f);

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
	}


	private void OnEnable()
	{
		transform.DOMoveY(0.2f, 0.5f);
		
		GetComponent<RotateScript>().SetRotationSpeed(player.GetComponent<RotateScript>().GetRotationSpeed());
		
	}

	private void PlayCloseAnim()
	{
		OnEyeReset(this);
		
		gameObject.SetActive(false);
	}

	private void EnableRotateScript(FinishLineReached sender)
	{
		rotateScript.enabled = true;
		rotateScript.SetRotationSpeed(player.GetComponent<RotateScript>().GetRotationSpeed());
	}
	
}
