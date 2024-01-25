using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText, livesText, timeText;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = currentScore.ToString();
        livesText.text = currentLives.ToString();
        timeText.text = ((int)showTime).ToString();
    }

    public static float currentScore = 0;

    public void AddScore(int addScore)
    {
        currentScore += addScore;

        scoreText.text = currentScore.ToString();
    }

    float currentLives = 5;

    public void RemoveLife()
    {
        currentLives--;

        if (currentLives <= 0)
            LoseGame();
        else
            livesText.text = currentLives.ToString();
    }

    void LoseGame()
    {
        SceneManager.LoadScene(E_Scenes.LoseScene.ToString());
    }

    public float showTime = 60f;

    private void Update()
    {
        showTime -= Time.deltaTime;

        if (showTime <= 0)
            WinGame();
        else
            timeText.text = ((int)showTime).ToString();
    }

    void WinGame()
    {
        SceneManager.LoadScene(E_Scenes.WinScene.ToString());
    }
}
