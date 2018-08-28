using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonImageToggle : MonoBehaviour
{

	[SerializeField] private Sprite notClickedSprite;
	[SerializeField] private Sprite clickedSprite;
	
	[SerializeField] private Image imageToChange;

	public UnityEvent ToggleIsOnEvent;
	public UnityEvent ToggleIsOffEvent;

	public AudioManagerScript audiomanager;

	private bool triggered = false;

	private void Start()
	{
		
	}

	public void Toggle()
	{
		if (triggered)
		{
			imageToChange.sprite = notClickedSprite;
			ToggleIsOffEvent.Invoke();
			triggered = false;
			
		}
		else
		{
			imageToChange.sprite = clickedSprite;
			ToggleIsOnEvent.Invoke();
			triggered = true;
		}
	}
}
