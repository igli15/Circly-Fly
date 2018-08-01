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

	private Rigidbody2D rb;

	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		//transform.Rotate(0,0,-rotationSpeed);
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
