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


	private void Awake()
	{
		findRightPosition = GetComponent<FindRightPosition>();
	}

	// Update is called once per frame
	void Update () {
		
	}

	public void OnObjectSpawn()
	{
		SpawnObstacles.gems.Add(this);
		findRightPosition.SpawnCorrectly();
	}

	
	
}
