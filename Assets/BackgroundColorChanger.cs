using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundColorChanger : MonoBehaviour
{
	private Camera camera;

	private Dictionary<int, Color> colorDicitonary = new Dictionary<int, Color>();

	private int currentRanomIndex = 0;
	
	[Serializable]
	public class BackgroundColor
	{
		public int index;
		public Color color;
	}
	
	public List<BackgroundColor> colorList = new List<BackgroundColor>();
	
	// Use this for initialization
	void Start () 
	{
		AssignIntToColors();

		camera = GetComponent<Camera>();

		FinishLineReached.OnFinishLineReached += ChangeColor;
	}

	private void ChangeColor(FinishLineReached sender)
	{
		int _randomColorindex = Random.Range(1, colorList.Count + 1);

		while (_randomColorindex == currentRanomIndex)
		{
			_randomColorindex = Random.Range(1, colorList.Count + 1);
		}

		currentRanomIndex = _randomColorindex;
		
		camera.DOColor(colorDicitonary[_randomColorindex], 1f);
	}

	private void AssignIntToColors()
	{
		for (int i = 0; i < colorList.Count; i++)
		{
			colorDicitonary.Add(colorList[i].index,colorList[i].color);
		}
	}
}
