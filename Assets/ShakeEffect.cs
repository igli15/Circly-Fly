using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ShakeEffect : MonoBehaviour {

	// Use this for initialization
	void OnEnable () 
	{
		transform.DOShakeScale(2,new Vector3(0.2f,0.2f,0.2f),8,30,true);
	}
	
}
