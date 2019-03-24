using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{

	[SerializeField] 
	private GameObject target;

	[SerializeField] 
	[Range(-100, 100)] private float rotationSpeed;
	
	private Rigidbody2D rb;
	
	// Use this for initialization
	void Start ()
	{
		rb = GetComponent<Rigidbody2D>();
	}
	
	 private void FixedUpdate()
        {
            rb.velocity = -Vector2.Perpendicular(transform.position - target.transform.position).normalized * rotationSpeed * Time.fixedDeltaTime;
    
            Vector2 dir = rb.velocity;
            
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            
        }
}
