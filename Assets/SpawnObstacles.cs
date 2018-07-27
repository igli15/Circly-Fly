using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{

	[SerializeField] 
	private GameObject obstacle;

	private float amountOfObstacles = 10;
	
	// Use this for initialization
	void Start ()
	{
		SpawnObstacle();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}

	private void SpawnObstacle()
	{

		for (int i = 0; i < amountOfObstacles; i++)
		{
			Instantiate(obstacle, transform.position, Quaternion.identity);
		}
	}
}
