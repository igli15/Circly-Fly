using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
	public static Action<PlayerCollisions> OnObstacleHit;
	public static Action<PlayerCollisions> OnObstaclePass;
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag("obstacle"))
		{
			if (null != OnObstaclePass)
			{
				OnObstaclePass(this);
			}
		}
	}
	
	
	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.CompareTag("obstacle"))
		{
			if (null != OnObstacleHit)
			{
				OnObstacleHit(this);
			}
		}
	}
}
