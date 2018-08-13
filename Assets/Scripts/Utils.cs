using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour 
{


	public static void LookAt2D(Transform transform,Vector2 dir,Vector3 axis)
	{
		float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
		
		transform.rotation = Quaternion.AngleAxis(angle, axis);
	}
}
