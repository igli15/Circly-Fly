using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{

	private GameObject player;

	private RotateScript rotateScript;

	private JumpScript jumpScript;
	
	// Use this for initialization

	private void Awake()
	{
		
	}

	void Start () 
	{

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (player == null)
		{
			player = GameObject.FindGameObjectWithTag("Player");

			if (player != null)
			{
				rotateScript = player.GetComponent<RotateScript>();
				jumpScript = player.GetComponent<JumpScript>();

				rotateScript.enabled = true;
				jumpScript.enabled = true;
			}
		}
	}
}
