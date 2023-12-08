using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    [SerializeField] private GameObject gameOverDisplay;
    [SerializeField] private AsteroidSpawner asteroidSpawner;
    [SerializeField] private TMP_Text gameOverText;
    [SerializeField] private ScoreSystem scoreSystem;

    private void Awake()
    {
        gameOverDisplay.SetActive(false);
    }

    public void PlayAgain()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GameEnd()
    {
        gameOverDisplay.SetActive(true);
        int finalScore = scoreSystem.EndTimer();
        gameOverText.text = "Your Score : " + finalScore.ToString();
        asteroidSpawner.enabled = false;

    }
}
