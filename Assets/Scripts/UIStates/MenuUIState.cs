using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEditor;
using UnityEngine;

public class MenuUIState : AbstractState<UIManager>
{
	[SerializeField]
	private GameObject menuCanvas;

	
	private CanvasGroup optionButtons;
	
	/*private RotateScript rotateScript;

	private JumpScript jumpScript;*/

	//private GameObject player;

	private void Awake()
	{
		optionButtons = GameObject.FindGameObjectWithTag("OptionCanvas").GetComponent<CanvasGroup>();
	}

	public override void Enter(IAgent pAgent)
	{

		base.Enter(pAgent);
		
		//player = GameObject.FindGameObjectWithTag("Player");
	
		//jumpScript = player.GetComponent<JumpScript>();
		//rotateScript = player.GetComponent<RotateScript>();

		//jumpScript.enabled = false;
		//rotateScript.enabled = false;

		menuCanvas.SetActive(true);

		optionButtons.alpha = 1;
		optionButtons.interactable = true;
		
		menuCanvas.GetComponent<CanvasGroup>().DOFade(1,1.5f);
		
	}

	private void Update()
	{
		
	}

	public override void Exit(IAgent pAgent)
	{
		optionButtons.alpha = 0;
		optionButtons.interactable = false;
		menuCanvas.SetActive(false);
		base.Exit(pAgent);
	}
	
}
