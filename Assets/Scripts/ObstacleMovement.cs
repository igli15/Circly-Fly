using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class ObstacleMovement : MonoBehaviour
{
	[SerializeField] 
	private float speed = 0.2f;

	private bool thrustUp;

	private Rigidbody2D rb;

	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
		

		thrustUp = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (thrustUp)
		{
			Debug.Log("thrusitng up");
			ThrustUp();
		}
		else
		{
			Debug.Log("thrusting down");
			ThrustDown();
		}
	}

	private void ThrustUp()
	{
		rb.velocity = transform.up * speed;
		Invoke("SetThrustToFalse",2);
	}

	private void ThrustDown()
	{
		rb.velocity = -transform.up * speed;
	
		
		Invoke("SetThrustToTrue",4);
	}

	private void SetThrustToTrue()
	{
		thrustUp = true;
		speed = Random.Range(0.5f, 1f);
		
	}
	private void SetThrustToFalse()
	{
		thrustUp = false;
		speed = Random.Range(0.5f, 1f);
		
	}
}
