using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour {

	private static DontDestroyOnLoad instance = null;

	public static DontDestroyOnLoad Instance { get { return instance; } }


	private void Awake()
	{

		if (instance == null)


			instance = this;


		else if (instance != this)
		{

			Destroy(gameObject);
			
		}
		DontDestroyOnLoad(gameObject);
	}

	
	
}
