using UnityEngine;

public class GemScript : MonoBehaviour, IPooleableObject
{
    public enum GemType
    {
        tier3Gem,
        tier2Gem,
        tier1Gem
    }

    private FindRightPosition findRightPosition;

    public GemType gemType;

    [SerializeField] private float maxGemHeight = 0.6f;

    [SerializeField] private float minGemHeight = 0.2f;

    public void OnObjectSpawn()
    {
        findRightPosition = GetComponent<FindRightPosition>();
        SpawnObstacles.gems.Add(this);
        findRightPosition.SpawnCorrectly();
    }


    // Update is called once per frame
    private void Update()
    {
    }

    private void Start()
    {
        FinishLineReached.OnFinishLineReached += RemoveGem;
        transform.position += transform.up * Random.Range(minGemHeight, maxGemHeight);
    }

    private void RemoveGem(FinishLineReached sender)
    {
        if (this != null)
        {
            if (SpawnObstacles.gems.Contains(this)) SpawnObstacles.gems.Remove(this);

            ObjectPooler.instance.DestroyFromPool(gemType.ToString(), gameObject);
        }
    }

    private void OnDestroy()
    {
        FinishLineReached.OnFinishLineReached -= RemoveGem;
    }
}