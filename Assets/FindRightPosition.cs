using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindRightPosition : MonoBehaviour
{
	
	private GameObject finishLine;
	
	private GameObject spawner;

	private void Start()
	{
		finishLine = GameObject.FindGameObjectWithTag("finishLine");
		spawner = GameObject.FindGameObjectWithTag("spawner");
		
		do
		{
			Vector2 _center = spawner.transform.position;

			Vector2 _pos = (Random.insideUnitCircle.normalized + (Vector2) spawner.transform.position) *
			               spawner.transform.localScale.x;
			Quaternion _rot = Quaternion.FromToRotation(Vector3.up, _center - _pos);

			transform.position = _pos;
			transform.rotation = _rot;

		} while (Vector2.Distance(transform.position, finishLine.transform.position) <= 2.4f);


	}

	// Update is called once per frame
	void Update()
	{

	}


}
