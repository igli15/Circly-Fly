using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHighscoreText : MonoBehaviour
{
	private Text text;

	private void OnEnable()
	{
		text = GetComponent<Text>();

		PlayerData.OnHighScoreChanged += SetHighScore;
		
	}

	public void SetHighScore(PlayerData sender)
	{
		if (this != null)
		{
			text.text = sender.highscore.ToString();
		}
	}
}
