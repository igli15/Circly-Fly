using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{

	private int highscore;
	
	private int tier3GemCount;

	private int tier2GemCount;

	private int tier1GemCount;
	
	
	// Use this for initialization
	void Start () 
	{
		
	}

	public int GetHighscore()
	{
		return highscore;
	}
	
	public int GetTier3GemCount()
	{
		return tier3GemCount;
	}
	
	public int GetTier2GemCount()
	{
		return tier2GemCount;
	}
	
	public int GetTier1GemCount()
	{
		return tier1GemCount;
	}

	public void Save()
	{
		JsonUtility.ToJson(this);
	}

	public void Load(string savedData)
	{
		JsonUtility.FromJsonOverwrite(savedData,this);
	}
	
	
}
