using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemScript : MonoBehaviour ,IPooleableObject
{

	public enum GemType
	{
		GreenGem,
		BlueGem,
		RareBlueGem
	}

	public GemType gemType;

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

	
}
