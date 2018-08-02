using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGems : MonoBehaviour
{
	[SerializeField]
	private GameObject gem;

	private List<GameObject> gemList;
	
	// Use this for initialization
	void Start ()
	{
		gemList = new List<GameObject>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
}
