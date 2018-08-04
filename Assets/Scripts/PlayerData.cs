using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

[Serializable]
public class PlayerData : MonoBehaviour
{
	[HideInInspector]
	public int highscore = 0;
	
	[HideInInspector]
	public int tier3GemCount = 0;

	[HideInInspector]
	public int tier2GemCount = 0;
	
	[HideInInspector]
	public int tier1GemCount = 0;

	private int levelScore = 0;


	private void Awake()
	{
		try
		{
			Load();
		}
		catch (Exception e)
		{
			Debug.Log(e);
		}
	
	}

	// Use this for initialization
	void Start ()
	{
		PlayerCollisions.OnObstacleHit += CheckHighscore;
		PlayerCollisions.OnObstacleHit += Save;
		
		PlayerCollisions.OnObstaclePass += sender => levelScore += 1;
		
		PlayerCollisions.OnGemCollected += CheckGem;
		
		Debug.Log("highscore is " + highscore);
	}

	private void CheckHighscore(PlayerCollisions sender)
	{
		if (levelScore > highscore)
		{
			highscore = levelScore;
		}
	}

	private void CheckGem(Collision2D collision)
	{
		if (collision.gameObject.GetComponent<GemScript>().gemType == GemScript.GemType.tier1Gem) tier1GemCount += 1;
		if (collision.gameObject.GetComponent<GemScript>().gemType == GemScript.GemType.tier2Gem) tier2GemCount += 1;
		if (collision.gameObject.GetComponent<GemScript>().gemType == GemScript.GemType.tier3Gem) tier3GemCount += 1;
	}

	public void Save(PlayerCollisions sender)
	{

		string data = JsonUtility.ToJson(this,true);
		
		File.WriteAllText(Application.persistentDataPath + "/PlayerData.json",Encryption.Encrypt(data));
		//Debug.Log(data);
	}

	public void Load()
	{
		string loadedData = Encryption.Decrypt(File.ReadAllText(Application.persistentDataPath + "/PlayerData.json"));
		JsonUtility.FromJsonOverwrite(loadedData,this);
	}
	
}
