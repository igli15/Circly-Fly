using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreAnimation : MonoBehaviour
{

	private Animator animator;
	
	// Use this for initialization
	void Start ()
	{
		animator = GetComponent<Animator>();
		TriggerManager.OnObstaclePass += Animate;
		animator.enabled = false;
	}

	private void Animate(Collider2D sender)
	{
		animator.enabled = true;
	}

	private void DisableAnimator()
	{
		animator.enabled = false;
	}

	private void OnDisable()
	{
		TriggerManager.OnObstaclePass -= Animate;
	}
}
