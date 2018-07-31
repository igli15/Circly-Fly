using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{

	private Rigidbody2D rb;
	private JumpScript jumpScript;
	private RotateScript rotateScript;

	
	
	void Start ()
	{
		jumpScript = GetComponent<JumpScript>();
		rb = GetComponent<Rigidbody2D>();
		rotateScript = GetComponent<RotateScript>();
		PlayerCollisions.OnObstacleHit += OnDeath;
	}


	private void OnDeath(PlayerCollisions sender)
	{
		jumpScript.canJump = false;
		if (rotateScript != null)
		{
			rotateScript.enabled = false;
		}

		rb.velocity = Vector2.zero;
		rb.gravityScale = 50;
		Invoke("RestartScene",2);
	}

	private void RestartScene()
	{
		SceneManager.LoadScene(0);
		/*transform.position = new Vector3(0,3,0);
		transform.rotation = Quaternion.identity;
		rotateScript.enabled = true;
		jumpScript.canJump = true;
		
		foreach (GameObject obstacle in SpawnObstacles.obstacles)
		{
			obstacle.GetComponent<FindRightPosition>().SpawnCorrectly();
		}*/
	}

	private void OnDestroy()
	{
		PlayerCollisions.OnObstacleHit -= OnDeath;
	}
}
