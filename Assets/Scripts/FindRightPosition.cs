using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class FindRightPosition : MonoBehaviour
{

	private GameObject finishLine;
	
	private GameObject spawner;

	private Vector3 initLocalScale;

	[SerializeField]
	[Range(0.1f,1.5f)]
	private float distanceBetweenObstacles = 1f;

	[SerializeField] 
	[Range(0.1f, 4)] 
	private float distanceFromStartLine = 2.5f;

	private void Awake()
	{
		finishLine = GameObject.FindGameObjectWithTag("finishLine");
		spawner = GameObject.FindGameObjectWithTag("spawner");	
		
		FinishLineReached.OnFinishLineReached += SpawnCorrectly;
	}

	private void Start()
	{
		if (transform.CompareTag("obstacle"))
		{
			SpawnObstacles.obstacles.Add(gameObject);
		}
		
		SpawnCorrectly();
	}

	private bool IsNear()
	{
		foreach (GameObject obj in SpawnObstacles.obstacles)
		{
			if (!obj.gameObject.Equals(gameObject) && Vector2.Distance(transform.position, obj.transform.position) <= distanceBetweenObstacles)
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

            Vector2 _pos = Random.insideUnitCircle.normalized * (spawner.GetComponent<SpriteRenderer>().sprite.bounds.extents.magnitude);

			_pos += new Vector2(spawner.transform.position.x,spawner.transform.position.y); //If the circle moves it moves with the circle
			
			Quaternion _rot = Quaternion.FromToRotation(Vector3.up, _pos - _center);

            transform.position = new Vector3(_pos.x,_pos.y,0);
			transform.rotation = _rot;
		}
		else
		{
			throw new Exception("spawner is null");
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
