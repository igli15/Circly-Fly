using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialPopUp : PopUp
{

	public bool isLastTrigger= false;

	// Use this for initialization
	void OnEnable ()
	{
		Time.timeScale = 0;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.anyKeyDown)
		{
			Time.timeScale = 1;
			if (isLastTrigger)
			{
				SceneManager.LoadScene(0);
				return;
			}
			
			Close();
			gameObject.SetActive(false);
		}
	}
	
	
}
