using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

    [SerializeField]
    private float fallingSpeed = 10;

	private Rigidbody2D rb;
	private JumpScript jumpScript;
	private RotateScript rotateScript;

	private SpringJoint2D spring;

	private GameObject spawner;

    private bool shouldAddForce = false;
	
	
	void Start ()
	{
		jumpScript = GetComponent<JumpScript>();
		rb = GetComponent<Rigidbody2D>();
		rotateScript = GetComponent<RotateScript>();
		spring = GetComponent<SpringJoint2D>();

		spawner = GameObject.FindGameObjectWithTag("spawner");
		PlayerCollisions.OnObstacleHit += OnDeath;
	}

    private void FixedUpdate()
    {
        if(shouldAddForce)
        {
            rb.AddForce((spawner.transform.position - transform.position).normalized * fallingSpeed);
        }
    }


    private void OnDeath(PlayerCollisions sender)
	{
		jumpScript.canJump = false;
		if (rotateScript != null)
		{
			rotateScript.enabled = false;
		}

		spring.breakForce = 0;
		spring.autoConfigureDistance =true;
        shouldAddForce = true;
		
		Invoke("RestartScene",2);
	}

	private void RestartScene()
	{
		SceneManager.LoadScene(0);
	}

	private void OnDestroy()
	{
		PlayerCollisions.OnObstacleHit -= OnDeath;
	}
}
