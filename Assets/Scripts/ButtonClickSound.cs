﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonClickSound : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		GetComponent<Button>().onClick.AddListener(PlayClickSound);
	}

	public void PlayClickSound()
	{
		AudioManagerScript.instance.PlaySound("click");
	}
}
