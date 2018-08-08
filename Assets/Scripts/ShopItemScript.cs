using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemScript : MonoBehaviour
{

	public static Action<ShopItemScript> OnSetAsDefault;
	
	private Text priceText;

	private GameObject image;
	
	public bool isUnlocked = false;

	private bool isDefault = false;

	public GemScript.GemType priceGemType;
	
	private Image currentButtonImage;

	private Image birdImage;

	
	public int index;

	[SerializeField] 
	private PlayerData playerData;

	[SerializeField] 
	private Sprite selectedImage;

	[SerializeField] 
	private Sprite notSelectedImage;
	
	// Use this for initialization

	private void Awake()
	{
		currentButtonImage = GetComponent<Button>().image;
		playerData.Load();
	}

	private void Start()
	{
		
		if (!isUnlocked)
		{
			birdImage = transform.GetChild(0).GetComponent<Image>();
			priceText = transform.GetChild(1).GetComponent<Text>();
			image = transform.GetChild(2).gameObject;
		}
		
		
		if (playerData.unlockedCharacter[index])
		{
			Unlock();
		}
	}

	public void ManageClick()
	{
		if (isUnlocked)
		{
			SetAsDefault();
		}
		else
		{
			Buy();
		}
		
		playerData.Save();
	}

	private void Update()
	{
		if (Input.GetKeyDown(KeyCode.A))
		{
			playerData.tier2GemCount += 100;
			playerData.tier3GemCount += 100;
		}
	}

	public void SetAsDefault()
	{
		if(OnSetAsDefault != null) OnSetAsDefault(this);
		playerData.defaultCharacter = index;
	}


	public void SetImageToSelected()
	{
		currentButtonImage.sprite = selectedImage;
		isDefault = true;
	}

	public void Reset()
	{
		currentButtonImage.sprite = notSelectedImage;
		isDefault = false;
	}
	
	private void Buy()
	{
		int _price = int.Parse(priceText.text);

		if (priceGemType == GemScript.GemType.tier1Gem && playerData.tier1GemCount >= _price)
		{
			playerData.SpendGems(_price,priceGemType);
			Unlock();
		}
		else if (priceGemType == GemScript.GemType.tier2Gem && playerData.tier2GemCount >= _price)
		{
			playerData.SpendGems(_price,priceGemType);
			Unlock();
		}
		else if (priceGemType == GemScript.GemType.tier3Gem && playerData.tier3GemCount >= _price)
		{
			playerData.SpendGems(_price,priceGemType);
			Unlock();
		}
		
	}

	private void Unlock()
	{
		if (priceText != null && image != null)
		{
			priceText.gameObject.SetActive(false);
			image.SetActive(false);
			birdImage.DOColor(Color.white, 0.2f);
			playerData.unlockedCharacter[index] = true;
			isUnlocked = true;
			SetAsDefault();
		}
	}

}
