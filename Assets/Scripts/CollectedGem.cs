using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectedGem : MonoBehaviour
{

	private GemScript gemScript
		;
	// Use this for initialization
	void Start ()
	{
		gemScript = GetComponent<GemScript>();
		PlayerCollisions.OnGemCollected += Collect;
	}

	private void Collect(Collision2D collision)
	{
		if (this != null)
		{
			
			string gemTag = collision.gameObject.GetComponent<GemScript>().gemType.ToString();
			Debug.Log("Gem Collected : " + gemTag);

			ObjectPooler.instance.DestroyFromPool(gemTag, collision.gameObject);
			if (SpawnObstacles.gems.Contains(gemScript))
			{
				SpawnObstacles.gems.Remove(gemScript);
			}
			
			
		}
	}
}
