using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterManager : MonoBehaviour
{
	
	private PlayerData playerData;
	
	// Use this for initialization


	private void Start()
	{
		playerData = GameObject.FindGameObjectWithTag("SaveLoadManager").GetComponent<PlayerData>();
		
		ShopItemScript.OnSetAsDefault += ChangeCharacter;
		
		ChangeCharacter(playerData.defaultCharacter);

		PlayAds.OnReviveAdFinished += ReviveRightCharacter;

	}

	public void ChangeCharacter(int index)
	{
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			transform.GetChild(i).transform.gameObject.SetActive(false);
		}
		
		transform.GetChild(index).gameObject.SetActive(true);
	}

	private void ChangeCharacter(ShopItemScript sender)
	{
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			transform.GetChild(i).transform.gameObject.SetActive(false);
		}
		
		transform.GetChild(sender.index).gameObject.SetActive(true);
	}

	private void OnDestroy()
	{
		ShopItemScript.OnSetAsDefault -= ChangeCharacter;
		PlayAds.OnReviveAdFinished -= ReviveRightCharacter;
	}

	public void ReviveRightCharacter(PlayAds sender = null)
	{
		transform.GetChild(playerData.defaultCharacter).GetComponent<PlayerDeath>().Revive();
	}
	

}
