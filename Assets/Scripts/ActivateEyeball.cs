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

		LookAtPlayer.OnEyeReset += CloseEye;
		PlayAds.OnReviveAdFinished += RevviveEye;

	}
	
	// Update is called once per frame
	void Update ()
	{
		
	}
	
	public void Enable()
	{
		animator.enabled = false;
		eyeball.SetActive(true);
		spriteRenderer.sprite = whiteEyeball;
	}

	public void CloseEye(LookAtPlayer sender)
	{
		animator.enabled = true;
		animator.SetBool("Revived",false);
		animator.SetBool("IsDead",true);
		
	}

	public void AnimateEye()
	{
		animator.enabled = true;
	}

	public void RevviveEye(PlayAds sender = null)
	{
		animator.enabled = true;
		animator.SetBool("IsDead",false);
		animator.SetBool("Revived",true);
	}

	private void OnDestroy()
	{
		LookAtPlayer.OnEyeReset -= CloseEye;
		PlayAds.OnReviveAdFinished -= RevviveEye;
	}
}
