using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
	private RotateScript rotateScript;
	
	// Use this for initialization
	void Start ()
	{
		rotateScript = GetComponent<RotateScript>();

		FinishLineReached.OnFinishLineReached += EnableRotateScript;
		PlayerCollisions.OnObstacleHit += DisableRotateScript;

	}

	private void OnDestroy()
	{

		FinishLineReached.OnFinishLineReached -= EnableRotateScript;
		PlayerCollisions.OnObstacleHit -= DisableRotateScript;
	}


	private void DisableRotateScript(PlayerCollisions sender)
	{
		rotateScript.enabled = false;
	}

	private void EnableRotateScript(FinishLineReached sender)
	{
		rotateScript.enabled = true;
	}
}
