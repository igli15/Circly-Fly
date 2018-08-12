using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RainSpawner : MonoBehaviour {

	
	
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
		InvokeRepeating("SpawnRaindrops",0.5f,0.5f);
	}

	private void SpawnRaindrops()
	{
		for (int i = 0; i < 15; i++)
		{
			ObjectPooler.instance.SpawnFromPool("RainDrop", new Vector3(Random.Range(-3, 5), transform.position.y + Random.Range(-2,0.5f), 0),
				Quaternion.identity);
		}

	}
}
