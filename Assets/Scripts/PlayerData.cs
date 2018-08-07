using System;
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

    private int levelScore;

    [HideInInspector] public int tier1GemCount = 0;

    [HideInInspector] public int tier2GemCount = 0;

    [HideInInspector] public int tier3GemCount = 0;

    public static Action<PlayerData> OnHighScoreChanged;
    public static Action<PlayerData> OnGemCountChanged;

    private bool callOnce = false;

    private void Awake()
    {
      if(File.Exists(Application.persistentDataPath + "/PlayerData.json"))
        Load();
        
    }

    // Use this for initialization
    private void Start()
    {
        PlayerCollisions.OnObstacleHit += CheckHighscore;
        PlayerCollisions.OnObstacleHit += Save;

        PlayerCollisions.OnObstaclePass += sender => levelScore += 1;

        PlayerCollisions.OnGemCollected += CheckGem;

        
    }

    private void Update()
    {  
            if (OnHighScoreChanged != null) OnHighScoreChanged(this);
            if (OnGemCountChanged != null) OnGemCountChanged(this);
            callOnce = true;
        
    }


    private void CheckHighscore(PlayerCollisions sender)
    {
        if (levelScore > highscore) highscore = levelScore;
        if (OnHighScoreChanged != null) OnHighScoreChanged(this);
    }
  

    private void CheckGem(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<GemScript>().gemType == GemScript.GemType.tier1Gem) tier1GemCount += 1;
        if (collision.gameObject.GetComponent<GemScript>().gemType == GemScript.GemType.tier2Gem) tier2GemCount += 1;
        if (collision.gameObject.GetComponent<GemScript>().gemType == GemScript.GemType.tier3Gem) tier3GemCount += 1;

        if (OnGemCountChanged != null) OnGemCountChanged(this);

    }

    public void Save(PlayerCollisions sender)
    {
        var data = JsonUtility.ToJson(this, true);

        File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", Encryption.Encrypt(data));
    }

    public void Load()
    {
        var loadedData = Encryption.Decrypt(File.ReadAllText(Application.persistentDataPath + "/PlayerData.json"));
        JsonUtility.FromJsonOverwrite(loadedData, this);
    }

    private void OnDestroy()
    {
        PlayerCollisions.OnObstacleHit -= CheckHighscore;
        PlayerCollisions.OnObstacleHit -= Save;

        PlayerCollisions.OnObstaclePass -= sender => levelScore += 1;

        PlayerCollisions.OnGemCollected -= CheckGem;

    }
}