using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class PlayAds : MonoBehaviour
{
	[SerializeField] 
	private PlayerData playerData;

	
	private void Start()
	{
		PlayerCollisions.OnObstacleHit += CheckIfShouldPlayAdd;
		//PlayerCollisions.OnObstacleHit += IncreaseDeathCount;

	}

	/*private void IncreaseDeathCount(PlayerCollisions sender)
	{
		playerData.deathCount += 1;
		Debug.Log(playerData.deathCount);
	}*/

	private void CheckIfShouldPlayAdd(PlayerCollisions sender)
	{
		if (playerData.deathCount >= 3)
		{
			ShowNormalAdd();
			playerData.deathCount = 0;
			Debug.Log("More than 3");
			playerData.Save();
		}
		else
		{
			Debug.Log(playerData.deathCount);
			playerData.deathCount += 1;
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

	public void ShowNormalAdd()
	{
		if (Advertisement.IsReady())
		{
			Advertisement.Show("video",new ShowOptions(){resultCallback = HandleResult});
		}
	}

	private void OnDestroy()
	{
		//PlayerCollisions.OnObstacleHit -= IncreaseDeathCount;
		PlayerCollisions.OnObstacleHit -= CheckIfShouldPlayAdd;
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
