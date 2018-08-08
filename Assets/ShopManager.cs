using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
	[SerializeField]
	private PlayerData playerdata;
	
	private GameObject[] shoppingItems;

	private ShopItemScript defaultCharacter;
	
	// Use this for initialization
	void Start ()
	{

		playerdata.Load();
		
		shoppingItems = GameObject.FindGameObjectsWithTag("ShopItem");
		ShopItemScript.OnSetAsDefault += SetAsDefault;
		
		foreach (ShopItemScript shopitem in GetComponentsInChildren<ShopItemScript>())
		{
			if (shopitem.index == playerdata.defaultCharacter)
			{
				Debug.Log(shopitem.index);
				defaultCharacter = shopitem;
			}
		}
		
		SetAsDefault(defaultCharacter);
		
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void SetAsDefault(ShopItemScript item)
	{
		
		foreach (GameObject obj in shoppingItems)
		{
			if(obj.transform != transform)
			obj.GetComponent<ShopItemScript>().Reset();
		}

		playerdata.defaultCharacter = item.index;
		item.SetImageToSelected();
		
		playerdata.Save();
		
	}

	private void OnDestroy()
	{
		ShopItemScript.OnSetAsDefault -= SetAsDefault;
	}
}
