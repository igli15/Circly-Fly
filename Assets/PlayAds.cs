using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class PlayAds : MonoBehaviour
{

	private float deathCount = 0;
	
	private void Start()
	{
		PlayerCollisions.OnObstacleHit += IncreaseDeathCount;
		PlayerCollisions.OnObstacleHit += CheckIfShouldPlayAdd;

	}

	private void IncreaseDeathCount(PlayerCollisions sender)
	{
		deathCount += 1;
	}

	private void CheckIfShouldPlayAdd(PlayerCollisions sender)
	{
		if (deathCount > 3)
		{
			ShowNormalAdd();
			deathCount = 0;
		}
	}

	public void ShowRewardedVideoAdd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show("rewardedVideo",new ShowOptions(){resultCallback = HandleResult});
		}
	}

	public void ShowNormalAdd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show("video",new ShowOptions(){resultCallback = HandleResult});
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
				;
			}
			case ShowResult.Skipped:
			{
				Debug.Log("add Skiped");
				break;
				;
			}
			case ShowResult.Failed:
			{
				Debug.Log("add Failed");
				break;
				;
			}
				
		}
	}
}
