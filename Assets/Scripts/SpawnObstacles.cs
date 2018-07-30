using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{


	public static List<GameObject> obstacles;

	[SerializeField] 
	private GameObject obstacle;

	private float amountOfObstacles = 10;
	
	// Use this for initialization
	void Start ()
	{
		obstacles = new List<GameObject>();
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
			GameObject _obstacle = Instantiate(obstacle, transform.position, Quaternion.identity);
		}
	}
}
