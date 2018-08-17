using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour,IAgent
{
	
	public Fsm<UIManager> fsm;

	[SerializeField] 
	private PlayerData playerData;
	
	// Use this for initialization
	void Start () 
	{
		if(fsm == null)
		fsm = new Fsm<UIManager>(this);
		
		GoToMenuState();
	}

	public void GoToLevelState()
	{
		if (playerData.firstPlay == true)
		{
			playerData.firstPlay = false;
			playerData.Save();
			SceneManager.LoadScene(1);
		}
		fsm.ChangeState<LevelUIState>();
	}

	public void GoToMenuState()
	{
		fsm.ChangeState<MenuUIState>();
	}

	public void GoToShopState()
	{
		fsm.ChangeState<ShopUIState>();
	}

	private void OnDestroy()
	{
		fsm = null;
	}
}
