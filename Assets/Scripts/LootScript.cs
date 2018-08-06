using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class LootScript : MonoBehaviour
{
    [SerializeField] private int dropLootChance = 50;

    public List<LootItem> lootItems = new List<LootItem>();

    private void Start()
    {
    }

    public void GenerateLootItem()
    {
        var _dropChance = Random.Range(0, 101);

        if (_dropChance > dropLootChance)
        {
            Debug.Log("No loot");
            return;
        }

        if (_dropChance <= dropLootChance)
        {
            var _itemWeight = 0;

            for (var i = 0; i < lootItems.Count; i++) _itemWeight += lootItems[i].rarity;
            var _randomValue = Random.Range(0, _itemWeight);

            for (var j = 0; j < lootItems.Count; j++)
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

    [Serializable]
    public class LootItem
    {
        public GameObject lootPrefab;
        public string name;
        public int rarity;
    }
}