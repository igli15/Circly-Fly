using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObstacles : MonoBehaviour
{

	[SerializeField] 
	private GameObject obstacle;

	private float amountOfObstacles = 2;
	
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
		Vector2 _center = transform.position;
		
		for (int i = 0; i < 5; i++)
		{
			Vector2 _pos = Random.insideUnitCircle.normalized * transform.localScale.x;
			Quaternion _rot = Quaternion.FromToRotation(Vector3.up,_center - _pos);
			
			Instantiate(obstacle, _pos, _rot);
		}
	}
}
