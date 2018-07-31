using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
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

	private GameObject spawner;

	private bool jump = false;

	public bool canJump;

	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		joint = GetComponent<SpringJoint2D>();

		initalJointDistance = joint.distance;
		
		spawner = GameObject.FindGameObjectWithTag("spawner");

		rb.freezeRotation = true;
		
		canJump = true;
	}


	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && canJump == true)
		{
			jump = true;
			Invoke("SetJumpToFalse",0.1f);
		}

		if (Input.GetMouseButtonUp(0))  
		{
			jump = false;
		}
	}

	private void SetJumpToFalse()
	{
		jump = false;
	}
	
	// Update is called once per frame
	private void FixedUpdate()
	{
		if (jump)
		{
			
			rb.AddForce(transform.up * jumpForce);
			
			if(joint != null)
			joint.distance = initalJointDistance + jumpDistance;
		}

		if (!jump)
		{
			rb.velocity = Vector2.zero;
			if(joint != null)
			joint.distance = initalJointDistance;
		}
	}
}
