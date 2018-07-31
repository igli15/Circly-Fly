﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRightPosition : MonoBehaviour
{
	
	private GameObject finishLine;
	
	private GameObject spawner;

	private CircleCollider2D spawnerCollider;

	[SerializeField]
	[Range(0.1f,1.5f)]
	private float distanceBetweenObstacles = 1f;

	[SerializeField] [Range(0.1f, 4)] 
	private float distanceFromStartLine = 2.5f;
	
	private void Start()
	{	
		finishLine = GameObject.FindGameObjectWithTag("finishLine");
		spawner = GameObject.FindGameObjectWithTag("spawner");
		spawnerCollider = spawner.GetComponent<CircleCollider2D>();
		
		SpawnObstacles.obstacles.Add(gameObject);


		FinishLineReached.OnFinishLineReached += SpawnCorrectly;
		
		SpawnCorrectly();
		
		
	}

	// Update is called once per frame
	void Update()
	{

	}

	private bool IsNear()
	{
		foreach (GameObject obj in SpawnObstacles.obstacles)
		{
			
			if (obj.transform != transform && Vector2.Distance(transform.position, obj.transform.position) <= distanceBetweenObstacles)
			{
				return true;
			}
		}

		return false;
	}

	private void FindNewPosition()
	{
		if (spawner != null)
		{
			Vector2 _center = spawner.transform.position;

            Vector2 _pos = Random.insideUnitCircle.normalized * (spawner.GetComponent<SpriteRenderer>().sprite.bounds.size.x/2 +spawner.transform.localScale.x/2);

			Quaternion _rot = Quaternion.FromToRotation(Vector3.up, _center - _pos);

            transform.position = new Vector3(_pos.x,_pos.y,0);
			transform.rotation = _rot;
		}
	}

	public void SpawnCorrectly(FinishLineReached sender = null)
	{
		if (this != null)
		{
			do
			{
				FindNewPosition();

			} while (Vector2.Distance(transform.position, finishLine.transform.position) <= distanceFromStartLine || IsNear());
		}

	}

}
