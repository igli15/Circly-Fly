using UnityEngine;

public class LevelData : MonoBehaviour
{
    private int levelIndex;

    [SerializeField] private LootScript lootScript;


    // Use this for initialization
    private void Start()
    {
        FinishLineReached.OnFinishLineReached += IncreaseLevelIndex;
        //lootScript.GenerateLootItem();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }


    public int GetLevelIndex()
    {
        return levelIndex;
    }


    public void IncreaseLevelIndex(FinishLineReached sender)
    {
        levelIndex += 1;
    }
}