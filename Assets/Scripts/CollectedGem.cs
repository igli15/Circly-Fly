using System;
using UnityEngine;

public class CollectedGem : MonoBehaviour
{
    private GemScript gemScript;

    // Use this for initialization
    private void Start()
    {
        gemScript = GetComponent<GemScript>();
        PlayerCollisions.OnGemCollected += Collect;
    }

    private void Collect(Collision2D collision)
    {
        if (this != null)
        {
            var gemTag = collision.gameObject.GetComponent<GemScript>().gemType.ToString();


            try
            {
                ObjectPooler.instance.DestroyFromPool(gemTag, collision.gameObject);
                if (SpawnObstacles.gems.Contains(gemScript)) SpawnObstacles.gems.Remove(gemScript);
            }
            catch 
            {
                Debug.Log("No object pooler found (maybe you are in tutorial scene)");
                Destroy(gameObject);
            }
        }
    }

    private void OnDestroy()
    {
        PlayerCollisions.OnGemCollected -= Collect;
    }
}