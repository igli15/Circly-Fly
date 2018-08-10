using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableNewHighScoreText : MonoBehaviour
{

	[SerializeField] 
	private GameObject newHighScoreText;
	
	// Use this for initialization
	void Start ()
	{
		PlayerData.OnHighscoreBroken += enableText;
	}

	private void enableText(PlayerData playerData)
	{
		newHighScoreText.SetActive(true);
	}
	
	

	private void OnDestroy()
	{
		PlayerData.OnHighscoreBroken -= enableText;
		newHighScoreText.SetActive(false);
	}
}
