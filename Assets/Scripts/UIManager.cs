using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour,IAgent
{
	
	public Fsm<UIManager> fsm;
	
	// Use this for initialization
	void Start () 
	{
		fsm = new Fsm<UIManager>(this);
		
		GoToMenuState();
	}

	public void GoToLevelState()
	{
		fsm.ChangeState<LevelUIState>();
	}

	public void GoToMenuState()
	{
		fsm.ChangeState<MenuUIState>();
	}
}
