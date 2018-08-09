using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ActivateEyeball : MonoBehaviour
{
	
	private SpriteRenderer spriteRenderer;
	private Animator animator;

	[SerializeField]
	private GameObject eyeball;

	[SerializeField] 
	private Sprite whiteEyeball;
	
	// Use this for initialization
	void Awake ()
	{
		animator = GetComponent<Animator>();
		spriteRenderer = GetComponent<SpriteRenderer>();

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void Enable()
	{
		animator.enabled = false;
		eyeball.SetActive(true);
		spriteRenderer.sprite = whiteEyeball;
	}

	

	public void AnimateEye()
	{
		animator.enabled = true;
	}

}
