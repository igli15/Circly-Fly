using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GemScript : MonoBehaviour ,IPooleableObject
{

	
	public enum GemType
	{
		GreenGem,
		BlueGem,
		RareBlueGem
	}

	public GemType gemType;

	[SerializeField] 
	private float maxGemHeight = 0.6f;

	[SerializeField] 
	private float minGemHeight = 0.2f;

	private FindRightPosition findRightPosition;

	// Update is called once per frame
	void Update () 
	{
		
	}

	public void OnObjectSpawn()
	{
		findRightPosition = GetComponent<FindRightPosition>();
		SpawnObstacles.gems.Add(this);
		findRightPosition.SpawnCorrectly();
	}

	private void OnDisable()
	{
		try
		{
			if (SpawnObstacles.gems.Contains(this))
			{
				SpawnObstacles.gems.Remove(this);
			}
		}
		catch (Exception e)
		{
			Debug.Log("collection was modified");
		}
	
	}


	private void Start()
	{
		transform.position += transform.up * Random.Range(minGemHeight, maxGemHeight);
	}
}
