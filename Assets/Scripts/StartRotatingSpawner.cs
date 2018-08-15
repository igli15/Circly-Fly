using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class StartRotatingSpawner : MonoBehaviour
{
	[SerializeField] 
	private LevelData levelData;
	
	private RotateScript rotateScript;
	
	
	// Use this for initialization
	void Start ()
	{
		rotateScript = GetComponent<RotateScript>();

		FinishLineReached.OnFinishLineReached += RotateBackwards;
	}

	private void RotateBackwards(FinishLineReached sender)
	{
		if (levelData.GetLevelIndex() > 10)
		{
			rotateScript.enabled = true;
			rotateScript.SetRotationSpeed(Random.Range(-10,5));
		}
	}

	private void OnDestroy()
	{
		FinishLineReached.OnFinishLineReached -= RotateBackwards;
	}
}
