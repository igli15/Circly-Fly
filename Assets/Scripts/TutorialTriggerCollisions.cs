using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialTriggerCollisions : MonoBehaviour
{

	public GameObject trigger1Popup;
	public GameObject trigger2Popup;
	public GameObject trigger3Popup;
	public GameObject trigger4Popup;
	public GameObject trigger5Popup;

	private bool entered1st = false;
	private bool entered2nd = false;
	private bool entered3rd = false;
	private bool entered4th = false;
	private bool entered5th = false;

	private void OnCollisionEnter2D(Collision2D other)
	{
		if (other.transform.CompareTag("obstacle"))
		{
			SceneManager.LoadScene(1);
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("1stTutorialTrigger"))
		{
			if (!entered1st)
			{
				trigger1Popup.SetActive(true);
				entered1st = true;
			}
		}
		if (other.CompareTag("2ndTutorialTrigger"))
		{
			if (!entered2nd)
			{
				trigger2Popup.SetActive(true);
				entered2nd = true;
			}
		}
		if (other.CompareTag("3rdTutorialTrigger"))
		{
			if (!entered3rd)
			{
				trigger3Popup.SetActive(true);
				entered3rd = true;
			}
		}
		if (other.CompareTag("4thTutorialTrigger"))
		{
			if (!entered4th)
			{
				trigger4Popup.SetActive(true);
				entered4th = true;
			}
		}
		if (other.CompareTag("5thTutorialTrigger"))
		{
			if (!entered5th)
			{
				trigger5Popup.SetActive(true);
				entered5th = true;
			}
		}
	}

}
