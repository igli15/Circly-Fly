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
            Debug.Log("Gem Collected : " + gemTag);

            ObjectPooler.instance.DestroyFromPool(gemTag, collision.gameObject);
            if (SpawnObstacles.gems.Contains(gemScript)) SpawnObstacles.gems.Remove(gemScript);
        }
    }
}