using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class JumpScript : MonoBehaviour
{
	
	[SerializeField] 
	[Range(0,1f)]
	private float jumpDistance = 0.2f;

	[SerializeField]
	[Range(0, 10)] 
	private float jumpForce = 3f;

	private float initalJointDistance;

	private Rigidbody2D rb;
	private SpringJoint2D joint;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		joint = GetComponent<SpringJoint2D>();

		initalJointDistance = joint.distance;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetMouseButton(0))
		{
			rb.AddForce(transform.up * jumpForce);
			joint.distance = initalJointDistance + jumpDistance;
		}

		if (Input.GetMouseButtonUp(0))
		{
			joint.distance = initalJointDistance;
		}
	}
}
