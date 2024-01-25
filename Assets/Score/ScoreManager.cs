using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = currentScore.ToString();
        livesText.text = currentLives.ToString();
    }

    float currentScore = 0;

    public void AddScore(int addScore)
    {
        currentScore += addScore;

        scoreText.text = currentScore.ToString();
    }

    float currentLives = 5;

    public void RemoveLife()
    {
        currentLives--;

        livesText.text = currentLives.ToString();
    }
}
