using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{

	private int levelIndex = 0;
	
	
	// Use this for initialization
	void Start ()
	{
		FinishLineReached.OnFinishLineReached += IncreaseLevelIndex;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	public int GetLevelIndex()
	{
		return levelIndex;
	}


	public void IncreaseLevelIndex(FinishLineReached sender)
	{
		levelIndex += 1;
	}
}
