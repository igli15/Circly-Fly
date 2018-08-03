using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedGem : MonoBehaviour {

	// Use this for initialization
	void Start ()
	{
		PlayerCollisions.OnGemCollected += Collect;
	}

	private void Collect(Collision2D collision)
	{
		if (this != null)
		{
			string gemTag = collision.gameObject.GetComponent<GemScript>().gemType.ToString();
			Debug.Log("Gem Collected : " + gemTag);

			ObjectPooler.instance.DestroyFromPool(gemTag, gameObject);
		}
	}
}
