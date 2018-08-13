using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class PlayAds : MonoBehaviour {


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
