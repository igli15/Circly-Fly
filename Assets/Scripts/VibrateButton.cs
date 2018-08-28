using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VibrateButton : MonoBehaviour
{


	[HideInInspector] public bool canVibrate = true;

	public void EnableVibration()
	{
		canVibrate = true;
	}
	
	public void DisableVibration()
	{
		canVibrate = false;
	}
}
