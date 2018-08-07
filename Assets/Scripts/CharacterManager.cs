using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour
{

	
	
	// Use this for initialization
	void Awake () 
	{
		ChangeCharacter(0);
	}

	public void ChangeCharacter(int index)
	{
		for (int i = 0; i < gameObject.transform.childCount; i++)
		{
			transform.GetChild(i).transform.gameObject.SetActive(false);
		}
		
		transform.GetChild(0).gameObject.SetActive(true);
	}
}
