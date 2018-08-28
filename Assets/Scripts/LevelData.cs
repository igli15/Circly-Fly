using System;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    private int levelIndex;

    [SerializeField] private LootScript lootScript;

    private VibrateButton vibrateButton;

    // Use this for initialization
    private void Start()
    {
        vibrateButton = GameObject.FindGameObjectWithTag("OptionCanvas").GetComponentInChildren<VibrateButton>();
        
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
        if(vibrateButton.canVibrate)
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