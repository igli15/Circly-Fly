using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{

	[SerializeField] 
	[Range(0,10)]
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
		//transform.Rotate(0,0,-rotationSpeed);
		transform.RotateAround(target.transform.position,new Vector3(0,0,1),-rotationSpeed);
		
	}
}
