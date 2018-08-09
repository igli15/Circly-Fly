using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CharacterManager : MonoBehaviour
{
	[SerializeField] 
	private PlayerData playerData;
	
	// Use this for initialization


	private void Start()
	{
		ShopItemScript.OnSetAsDefault += ChangeCharacter;
		
		ChangeCharacter(playerData.defaultCharacter);
		
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
	}
}
