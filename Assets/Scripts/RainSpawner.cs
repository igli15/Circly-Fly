using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawner : MonoBehaviour
{

	[SerializeField] private int spawnAmount = 12;
	[SerializeField] private int spawnRate = 1;
	
	
	// Use this for initialization
	void Start () 
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}

	public void StartRaining()
	{
		InvokeRepeating("SpawnRaindrops",spawnRate,spawnRate);
	}

	private void SpawnRaindrops()
	{
		for (int i = 0; i < spawnAmount; i++)
		{
			ObjectPooler.instance.SpawnFromPool("RainDrop", new Vector3(Random.Range(-3, 5), transform.position.y + Random.Range(-2,0.5f), 0),
				Quaternion.identity);
		}

	}
}
