﻿using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

public class MenuUIState : AbstractState<UIManager>
{
	[SerializeField]
	private GameObject menuCanvas;

	[SerializeField] 
	private SpawnObstacles spawnObstacles;

	[SerializeField] 
	private GameObject finishLine;

	[SerializeField] 
	private GameObject levelManagers;
	
	private RotateScript rotateScript;

	private JumpScript jumpScript;

	private GameObject player;

	private void Awake()
	{
		
	}

	public override void Enter(IAgent pAgent)
	{
		
		player = GameObject.FindGameObjectWithTag("Player");

		if (player != null)
		{
			jumpScript = player.GetComponent<JumpScript>();
			rotateScript = player.GetComponent<RotateScript>();
		}

		base.Enter(pAgent);

		if (jumpScript != null)
		{
			jumpScript.enabled = false;
			rotateScript.enabled = false;
		}

		menuCanvas.SetActive(true);
		
		menuCanvas.GetComponent<CanvasGroup>().DOFade(1,1.5f);
		
	}

	private void Update()
	{
		
	}

	public override void Exit(IAgent pAgent)
	{

		menuCanvas.SetActive(false);
		base.Exit(pAgent);
	}
	
}
