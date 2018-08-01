using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using DG.Tweening.Core;
using UnityEngine;

public class FindRightPosition : MonoBehaviour
{
	
	
	private GameObject finishLine;
	
	private GameObject spawner;

	private CircleCollider2D spawnerCollider;

	private Vector3 initLocalScale;

	[SerializeField]
	[Range(0.1f,1.5f)]
	private float distanceBetweenObstacles = 1f;

	[SerializeField] 
	[Range(0.1f, 4)] 
	private float distanceFromStartLine = 2.5f;


	[SerializeField] 
	[Range(0, 1f)] 
	private float scaleTime = 0.2f;
	
	private void Start()
	{	
		finishLine = GameObject.FindGameObjectWithTag("finishLine");
		spawner = GameObject.FindGameObjectWithTag("spawner");
		spawnerCollider = spawner.GetComponent<CircleCollider2D>();
	
		SpawnObstacles.obstacles.Add(gameObject);

		initLocalScale = transform.lossyScale;

		FinishLineReached.OnFinishLineReached += SpawnCorrectly;
		FinishLineReached.OnFinishLineReached += IncreaseScale;
		
		SpawnCorrectly();
		IncreaseScale();
		
		
		
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

            Vector2 _pos = Random.insideUnitCircle.normalized * (spawner.GetComponent<SpriteRenderer>().sprite.bounds.extents.magnitude);

			_pos += new Vector2(spawner.transform.position.x,spawner.transform.position.y); //If the circle moves it moves with the circle
			
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

	private void IncreaseScale(FinishLineReached sender = null)
	{
		if (this != null)
		{
			transform.localScale = Vector3.zero;
			transform.DOScale(initLocalScale, scaleTime);
		}
	}

}
