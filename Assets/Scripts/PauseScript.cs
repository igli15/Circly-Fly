using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{

	public static bool canPause = true;
	
	private CanvasGroup canvasGroup;

	[SerializeField] 
	private GameObject pauseButton;

	// Use this for initialization
	void Start ()
	{
		canvasGroup = GetComponent<CanvasGroup>();
	}
	
	
	void Update () 
	{
		if (Input.anyKeyDown && canvasGroup.alpha >= 0.9f)
		{
			Unpause();
		}
		
	}

	public void Unpause()
	{
		Time.timeScale = 1;
		pauseButton.SetActive(true);
		GetComponent<PopUp>().Close();
	}

	public void Pause()
	{
		if (canPause)
		{
			pauseButton.SetActive(false);
			GetComponent<PopUp>().Show();
			Time.timeScale = 0;
		}
	}
}
