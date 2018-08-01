using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
	private Action<RotateScript> OnIncreaseSpeed;
	
	[SerializeField] 
	[Range(0,100)]
	private float rotationSpeed = 2;

	[SerializeField] 
	private GameObject target;
	
	// Use this for initialization
	void Start ()
	{

	}
	
	// Update is called once per frame
	void Update ()
	{
		transform.RotateAround(target.transform.position,new Vector3(0,0,1),-rotationSpeed * Time.deltaTime);
	}

	public void IncreaseRotationSpeed(float increment)
	{
		if(OnIncreaseSpeed != null) OnIncreaseSpeed(this);
		rotationSpeed += increment;
	}
	


	private void FixedUpdate()
	{
		
	}
}
