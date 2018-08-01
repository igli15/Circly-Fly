using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{

	[SerializeField] 
	private float scoreIncrement = 1;
	
	private Text text;

	private float score = 0;
	
	// Use this for initialization
	void Start ()
	{
		text = GetComponent<Text>();
		text.text = score.ToString();
		PlayerCollisions.OnObstaclePass += IncreaseScore;
	}

	private void IncreaseScore(PlayerCollisions sender)
	{
		score += 1;
		
		if(text != null)
		text.text = text.text = score.ToString();
	}
}
