using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StartRotatingSpawner : MonoBehaviour
{
	private int rotateLaps = 0;
	
	private RotateScript rotateScript;
	
	
	// Use this for initialization
	void Start ()
	{
		rotateScript = GetComponent<RotateScript>();

		FinishLineReached.OnFinishLineReached += RotateBackwards;
	}

	private void RotateBackwards(FinishLineReached sender)
	{
		rotateLaps += 1;
		Debug.Log(rotateLaps);
		
		if (rotateLaps == 3)
		{
			rotateScript.enabled = true;
			rotateScript.SetRotationSpeed(Random.Range(-7,5));
			
		}
		else if (rotateLaps > 3)
		{
			rotateScript.enabled = false;
			rotateLaps = 0;
		}
	}

	private void OnDestroy()
	{
		FinishLineReached.OnFinishLineReached -= RotateBackwards;
	}
}
