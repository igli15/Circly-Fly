using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class CharacterManager : MonoBehaviour
{
	[SerializeField] 
	private PlayerData playerData;
	
	// Use this for initialization
	void Awake () 
	{
		playerData.Load();
		
		//ChangeCharacter(playerData.defaultCharacter);
		
		//ShopItemScript.OnSetAsDefault += ChangeCharacter;
	}

	private void Start()
	{
		
		ChangeCharacter(playerData.defaultCharacter);
		
		
		ShopItemScript.OnSetAsDefault += ChangeCharacter;
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
