using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIState : AbstractState<UIManager>
{

	[SerializeField] 
	private GameObject levelCanvas;

	[SerializeField] 
	private GameObject finishLine;

	[SerializeField] 
	private GameObject levelManagers;

	[SerializeField] 
	private JumpScript jumpScript;

	[SerializeField]
	private RotateScript rotateScript;

	[SerializeField] 
	private SpawnObstacles spawnObstacles;

	[SerializeField] 
	private GameObject menuCanvas;
	

	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);
		levelCanvas.SetActive(true);
		
		finishLine.SetActive(true);
		levelManagers.SetActive(true);
		jumpScript.enabled = true;
		rotateScript.enabled = true;
		spawnObstacles.enabled = true;
		menuCanvas.SetActive(false);
	}

	public void Update()
	{
		Debug.Log("test");
	}

	public override void Exit(IAgent pAgent)
	{
		base.Exit(pAgent);
		levelCanvas.SetActive(false);
	}
}
