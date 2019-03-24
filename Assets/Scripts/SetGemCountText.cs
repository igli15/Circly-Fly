using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetGemCountText : MonoBehaviour
{
	private Text text;
	
	public enum GemTier
	{
		Tier1,
		Tier2,
		Tier3
	}

	public GemTier gemTier;
	
	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text>();
		PlayerData.OnGemCountChanged += SetGemCount;
	}

	public void SetGemCount(PlayerData sender)
	{
		if (this != null)
		{
			if (gemTier == GemTier.Tier1) text.text = sender.tier1GemCount.ToString();
			if (gemTier == GemTier.Tier2) text.text = sender.tier2GemCount.ToString();
			if (gemTier == GemTier.Tier3) text.text = sender.tier3GemCount.ToString();
		}
	}

	private void OnDestroy()
	{
		PlayerData.OnGemCountChanged -= SetGemCount;
	}
}
