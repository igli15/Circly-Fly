using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour
{
	public static Action<Collider2D> OnObstaclePass;
	private bool passed = false;
	
	
	// Use this for initialization
	void Start ()
	{
		FinishLineReached.OnFinishLineReached += ResetPassage;
	}

	
	
	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform.CompareTag("Player"))
			if (null != OnObstaclePass && !passed)
			{
				OnObstaclePass(other);
				passed = true;
			}
	}

	private void ResetPassage(FinishLineReached sender)
	{
		passed = false;
	}

	private void OnDestroy()
	{
		FinishLineReached.OnFinishLineReached -= ResetPassage;
	}
}
