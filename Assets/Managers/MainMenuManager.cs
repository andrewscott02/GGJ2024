using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    private void Start()
    {
        if (scoreText != null)
        {
            scoreText.text = ScoreManager.currentScore.ToString();
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(E_Scenes.GameScene.ToString());
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(E_Scenes.MainMenu.ToString());
    }
}

public enum E_Scenes
{
    GameScene, MainMenu, LoseScene, WinScene
}