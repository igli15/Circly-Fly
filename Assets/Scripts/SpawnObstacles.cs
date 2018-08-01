﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{

	public static List<GameObject> obstacles;

	[SerializeField] 
	private GameObject obstacle;

	[SerializeField] 
	private LevelData levelData;

	private int amountOfObstacles = 0;
	
	// Use this for initialization
	void Start ()
	{
		obstacles = new List<GameObject>();
		FinishLineReached.OnFinishLineReached += SpawnRightAmountOfObstacles;
	}
	
	private void SpawnObstacle(int pAmountOfObstacles)
	{
		pAmountOfObstacles = amountOfObstacles - obstacles.Count;
		if (pAmountOfObstacles <= 0)
		{
			pAmountOfObstacles = 0;
		}	
		
		for (int i = 0; i < pAmountOfObstacles; i++)
		{
			if(this != null)
			Instantiate(obstacle, transform.position, Quaternion.identity);
		}
	}

	private void SpawnRightAmountOfObstacles(FinishLineReached sender = null)
	{
		
		if (levelData.GetLevelIndex() <= 2)
		{
			amountOfObstacles = Random.Range(4, 6);
			SpawnObstacle(amountOfObstacles);
		}
		else if (levelData.GetLevelIndex() <= 4 && levelData.GetLevelIndex() > 2)
		{
			amountOfObstacles = Random.Range(6, 8);
			SpawnObstacle(amountOfObstacles);
		}
		else if (levelData.GetLevelIndex() <= 6 && levelData.GetLevelIndex() > 4)
		{
			amountOfObstacles = Random.Range(8, 10);
			SpawnObstacle(amountOfObstacles);
		}
		else if(levelData.GetLevelIndex() > 6)
		{
			amountOfObstacles = Random.Range(10, 14);
			SpawnObstacle(amountOfObstacles);
		}

	}
}