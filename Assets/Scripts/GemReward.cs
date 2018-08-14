using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GemReward : MonoBehaviour
{

	[SerializeField] 
	private LootScript lootScript;


	[SerializeField]
	private PlayerData playerData;

	[SerializeField]
	private Image gemImage;

	[SerializeField] 
	private Text gemAmount;
	
	// Use this for initialization
	void OnEnable () 
	{
		GenerateLoot();
	}

	public void GenerateLoot()
	{
		LootScript.LootItem generatedLoot = lootScript.GetRandomItem();
		int amount = 0;
		
		if (generatedLoot.lootPrefab.GetComponent<GemScript>().gemType == GemScript.GemType.tier1Gem)
		{
			amount = (Random.Range(1, 3));
			playerData.IncreaseGemAmount(amount,GemScript.GemType.tier1Gem);
		}
		if (generatedLoot.lootPrefab.GetComponent<GemScript>().gemType == GemScript.GemType.tier2Gem)
		{
			amount = (Random.Range(5, 10));
			playerData.IncreaseGemAmount(amount,GemScript.GemType.tier2Gem);
		}
		if (generatedLoot.lootPrefab.GetComponent<GemScript>().gemType == GemScript.GemType.tier3Gem)
		{
			amount = (Random.Range(10,15));
			playerData.IncreaseGemAmount(amount,GemScript.GemType.tier3Gem);
		}

		gemImage.sprite = generatedLoot.lootPrefab.GetComponent<SpriteRenderer>().sprite;
		gemAmount.text = amount.ToString();

	}
}
