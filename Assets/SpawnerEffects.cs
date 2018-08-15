using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SpawnerEffects : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		FinishLineReached.OnFinishLineReached += FinishLineEffects;
	}

	private void FinishLineEffects(FinishLineReached sender)
	{
		transform.DOPunchRotation(new Vector3(5, 5f,5f), 1f, 8, 1);
	}
	
}
