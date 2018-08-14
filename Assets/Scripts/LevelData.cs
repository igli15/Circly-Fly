using System;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    private int levelIndex;

    [SerializeField] private LootScript lootScript;

    // Use this for initialization
    private void Start()
    {
        FinishLineReached.OnFinishLineReached += IncreaseLevelIndex;
        PlayerCollisions.OnObstacleHit += Vibrate;
        //lootScript.GenerateLootItem();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    private void Vibrate(PlayerCollisions sender)
    {
        Handheld.Vibrate();
    }

    public int GetLevelIndex()
    {
        return levelIndex;
    }


    public void IncreaseLevelIndex(FinishLineReached sender)
    {
        levelIndex += 1;
    }

    private void OnDestroy()
    {
        FinishLineReached.OnFinishLineReached -= IncreaseLevelIndex;
        PlayerCollisions.OnObstacleHit -= Vibrate;
    }
}