using UnityEngine;
using UnityEngine.UI;

public class ScoreBehaviour : MonoBehaviour
{
    private float score;

    [SerializeField] private float scoreIncrement = 1;

    private Text text;

    // Use this for initialization
    private void Start()
    {
        text = GetComponent<Text>();
        text.text = score.ToString();
        PlayerCollisions.OnObstaclePass += IncreaseScore;
    }

    private void IncreaseScore(PlayerCollisions sender)
    {
        score += scoreIncrement;
        if (text != null)
            text.text = text.text = score.ToString();
    }
}