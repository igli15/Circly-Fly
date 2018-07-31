using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCollisions : MonoBehaviour
{
	public static Action<PlayerCollisions> OnObstacleHit;


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
