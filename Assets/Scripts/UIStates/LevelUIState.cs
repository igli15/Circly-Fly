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

	
	private JumpScript jumpScript;

	
	private RotateScript rotateScript;

	private GameObject player;

	[SerializeField] 
	private SpawnObstacles spawnObstacles;

	[SerializeField] 
	private GameObject menuCanvas;
	

	public override void Enter(IAgent pAgent)
	{
		player = GameObject.FindGameObjectWithTag("Player");

		jumpScript = player.GetComponent<JumpScript>();
		rotateScript = player.GetComponent<RotateScript>();
		
		base.Enter(pAgent);
		
		levelCanvas.SetActive(true);
		
		finishLine.SetActive(true);
		levelManagers.SetActive(true);
		jumpScript.enabled = true;
		rotateScript.enabled = true;
		spawnObstacles.enabled = true;
		menuCanvas.SetActive(false);
	}


	public override void Exit(IAgent pAgent)
	{
		base.Exit(pAgent);
		levelCanvas.SetActive(false);
	}
}
