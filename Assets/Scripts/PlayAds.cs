using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.SceneManagement;

public class PlayAds : MonoBehaviour
{
	[SerializeField] 
	private PlayerData playerData;

	public static Action<PlayAds> OnReviveAdFinished;
	

	
	private void Start()
	{
		
	}

	public void CheckIfShouldPlayAdd()
	{
		Debug.Log(playerData.deathCount);
		if (playerData.deathCount >= 3)
		{
			ShowNormalAdd();
			playerData.deathCount = 0;
			playerData.Save();
		}
		
	}

	public void ShowRewardedVideoAdd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show("rewardedVideo",new ShowOptions(){resultCallback = HandleResult});
		}
	}

	public void ShowReviveVideo()
	{
		Advertisement.Show("rewardedVideo",new ShowOptions(){resultCallback = HandleReviveResult});
	}

	public void ShowNormalAdd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show("video");
		}
	}


	private void HandleResult(ShowResult showResult)
	{
		switch (showResult)
		{
			case ShowResult.Finished:
			{
				Debug.Log("addFinshied");
				break;
			}
			case ShowResult.Skipped:
			{
				Debug.Log("add Skiped");
				break;
			}
			case ShowResult.Failed:
			{
				Debug.Log("add Failed");
				break;
			}
				
		}
	}
	
	private void HandleReviveResult(ShowResult showResult)
	{
		switch (showResult)
		{
			case ShowResult.Finished:
			{
				if (OnReviveAdFinished != null) OnReviveAdFinished(this);
				break;
			}
			case ShowResult.Skipped:
			{
				Debug.Log("add Skiped");
				SceneManager.LoadScene(0);
				break;
			}
			case ShowResult.Failed:
			{
				Debug.Log("add Failed");
				SceneManager.LoadScene(0);
				break;
			}
				
		}
	}
}
