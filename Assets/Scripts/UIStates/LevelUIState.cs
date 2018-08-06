using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelUIState : AbstractState<UIManager>
{

	[SerializeField] 
	public GameObject levelCanvas;
	

	public override void Enter(IAgent pAgent)
	{
		base.Enter(pAgent);
		levelCanvas.SetActive(true);
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
