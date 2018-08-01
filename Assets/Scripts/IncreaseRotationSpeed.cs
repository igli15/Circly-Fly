using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseRotationSpeed : MonoBehaviour
{

	private RotateScript rotateScript;

	[SerializeField] 
	private float Speedincrement = 10;
	
	// Use this for initialization
	void Start ()
	{
		rotateScript = GetComponent<RotateScript>();
		
		FinishLineReached.OnFinishLineReached += IncreaseSpeed;
	}

	private void IncreaseSpeed(FinishLineReached sender)
	{
		rotateScript.IncreaseRotationSpeed(Speedincrement);
	}
}
