using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class JumpScript : MonoBehaviour
{
	
	[SerializeField] 
	[Range(0,10)]
	private float jumpSpeed = 0.2f;

	private Rigidbody2D rb;
	private SpringJoint2D joint;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		joint = GetComponent<SpringJoint2D>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton(0))
		{
			rb.AddForce(transform.up * jumpSpeed);
			joint.distance = 2.4f;
		}

		if (Input.GetMouseButtonUp(0))
		{
			joint.distance = 2.16f;
		}
	}
}
