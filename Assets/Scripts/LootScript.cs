using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootScript : MonoBehaviour
{

	[SerializeField] 
	private int dropLootChance = 50;

	[Serializable]
	public class LootItem
	{
		public string name;
		public int rarity;
		public GameObject lootPrefab;
	}

	public List<LootItem> lootItems = new List<LootItem>();
	
	void Start () 
	{
		
	}

	public void GenerateLootItem()
	{
		int _dropChance = Random.Range(0, 101);

		if (_dropChance > dropLootChance)
		{
			Debug.Log("No loot");
			return;
		}
		
		if (_dropChance <= dropLootChance)
		{
			int _itemWeight = 0;

			for (int i = 0; i < lootItems.Count; i++)
			{
				_itemWeight += lootItems[i].rarity;
			}

			int _randomValue = Random.Range(0, _itemWeight);

			for (int j = 0; j < lootItems.Count; j++)
			{
				if (_randomValue <= lootItems[j].rarity)
				{
					ObjectPooler.instance.SpawnFromPool(lootItems[j].name, transform.position, Quaternion.identity);
					return;
				}
		
				_randomValue -= lootItems[j].rarity;
			}
		}

	}
}
