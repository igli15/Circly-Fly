using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinishLineReached : MonoBehaviour
{

	[SerializeField] 
	private GameObject finishLine;

	public static Action<FinishLineReached> OnFinishLineReached;

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.transform == finishLine.transform)
		{
			if (OnFinishLineReached != null) OnFinishLineReached(this);
		}
	}
}
