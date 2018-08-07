using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MenuUIState : AbstractState<UIManager>
{
	[SerializeField]
	private GameObject menuCanvas;

	[SerializeField] 
	private RotateScript rotateScript;

	[SerializeField]
	private JumpScript jumpScript;

	[SerializeField] 
	private SpawnObstacles spawnObstacles;

	[SerializeField] 
	private GameObject finishLine;

	[SerializeField] 
	private GameObject levelManagers;
	
	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);
		jumpScript.enabled = false;
		rotateScript.enabled = false;
		menuCanvas.SetActive(true);
		
		menuCanvas.GetComponent<CanvasGroup>().DOFade(1,1.5f);
		
	}

	private void Update()
	{
		
	}

	public override void Exit(IAgent pAgent)
	{
		finishLine.SetActive(true);
		levelManagers.SetActive(true);
		jumpScript.enabled = true;
		rotateScript.enabled = true;
		spawnObstacles.enabled = true;
		menuCanvas.SetActive(false);
		
		base.Exit(pAgent);
	}
}
