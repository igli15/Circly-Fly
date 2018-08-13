using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[Serializable]
public class PlayerData : MonoBehaviour
{

    [SerializeField] 
    private UIManager uiManager;
    
    [HideInInspector] public int highscore = 0;

    [HideInInspector] public int deathCount = 0;

    private int levelScore;

    [HideInInspector] public int tier1GemCount = 0;

    [HideInInspector] public int tier2GemCount = 0;

    [HideInInspector] public int tier3GemCount = 0;

    [HideInInspector] public int defaultCharacter = 0;

    [HideInInspector] public bool[] unlockedCharacter;   

    public static Action<PlayerData> OnHighScoreChanged;
    public static Action<PlayerData> OnGemCountChanged;
    
    
    public static Action<PlayerData> OnHighscoreBroken;

   // private bool callOnce = false;

    private void Awake()
    {

        unlockedCharacter = new bool[10];
        unlockedCharacter[0] = true;
        
        
        Load();

    }
    


    // Use this for initialization
    private void Start()
    {
        PlayerCollisions.OnObstacleHit += CheckHighscore;
        PlayerCollisions.OnObstacleHit += Save;

        TriggerManager.OnObstaclePass += IncreaseScore;
        TriggerManager.OnObstaclePass += CheckHighscore;

        PlayerCollisions.OnGemCollected += CheckGem;
    }

    private void Update()
    {  
            if (OnHighScoreChanged != null) OnHighScoreChanged(this);
            if (OnGemCountChanged != null) OnGemCountChanged(this);

        if (Input.GetKeyDown(KeyCode.R))
        {
            tier1GemCount = 0;
            tier2GemCount = 0;
            tier3GemCount = 0;

            unlockedCharacter[1] = false;
            unlockedCharacter[2] = false;
            unlockedCharacter[3] = false;
            unlockedCharacter[4] = false;
            unlockedCharacter[5] = false;
            
            defaultCharacter = 0;

            highscore = 0;
            
            Save(null);
        }
        
//        Debug.Log(defaultCharacter);
    }

    public void SpendGems(int amount,GemScript.GemType gemType)
    {
        if (gemType == GemScript.GemType.tier1Gem) tier1GemCount -= amount;
        if (gemType == GemScript.GemType.tier2Gem) tier2GemCount -= amount;
        if (gemType == GemScript.GemType.tier3Gem) tier3GemCount -= amount;
        
        Save(null);
        
    }


    private void CheckHighscore(PlayerCollisions sender)
    {
        
        if (levelScore > highscore)
        {
            highscore = levelScore;
            if (OnHighScoreChanged != null) OnHighScoreChanged(this);
        }

    }
    
    private void CheckHighscore(Collider2D sender)
    {
        Debug.Log(highscore);
        Debug.Log(levelScore);
        if (levelScore > highscore)
        {
            if (OnHighscoreBroken != null) OnHighscoreBroken(this);
        }
    }
    
    private void IncreaseScore(Collider2D sender)
    {
        levelScore += 1;
    }



    private void CheckGem(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GemScript>().gemType == GemScript.GemType.tier1Gem) tier1GemCount += 1;
        if (collision.gameObject.GetComponent<GemScript>().gemType == GemScript.GemType.tier2Gem) tier2GemCount += 1;
        if (collision.gameObject.GetComponent<GemScript>().gemType == GemScript.GemType.tier3Gem) tier3GemCount += 1;

        if (OnGemCountChanged != null) OnGemCountChanged(this);

    }

    public void Save(PlayerCollisions sender = null)
    {
        var data = JsonUtility.ToJson(this, true);
       // Debug.Log(data);
        File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", Encryption.Encrypt(data));
    }
    
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath + "/PlayerData.json"))
        {
            var loadedData = Encryption.Decrypt(File.ReadAllText(Application.persistentDataPath + "/PlayerData.json"));
            JsonUtility.FromJsonOverwrite(loadedData, this);
        }
    }

    private void OnDestroy()
    {
        PlayerCollisions.OnObstacleHit -= CheckHighscore;
        PlayerCollisions.OnObstacleHit -= Save;

        TriggerManager.OnObstaclePass -= IncreaseScore;

        PlayerCollisions.OnGemCollected -= CheckGem;

        levelScore = 0;
        highscore = 0;

    }
}