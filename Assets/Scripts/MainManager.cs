using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainManager : MonoBehaviour
{
    public Button pauseButton;
    public Button continueButton;
    public Button restartButton;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI timeText;
    public TextMeshProUGUI gameOverText;
    public int score;
    public float time;
    public bool gameOver;

    private void Start()
    {
        gameOver = false;
        scoreText.gameObject.SetActive(true);
        timeText.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(false);
        restartButton.gameObject.SetActive(false);
        Time.timeScale = 1;
        time = 61;

    }
    public void BackToMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void FixedUpdate()
    {
        time -= Time.deltaTime;
        timeText.text = (int)time + " Seconds Left";
        if (time<=0 || gameOver)
        {
            gameOverText.text = "Game Over Your Score : " + score;
            gameOverText.gameObject.SetActive(true);
            restartButton.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            timeText.gameObject.SetActive(false);
            Time.timeScale = 0;
        }
    }
    public void PauseGame()
    {
        if (Time.timeScale==1)
        {
            Time.timeScale = 0;
            pauseButton.gameObject.SetActive(false);
            continueButton.gameObject.SetActive(true);
        }
        else if (Time.timeScale==0)
        {
            Time.timeScale = 1;
            pauseButton.gameObject.SetActive(true);
            continueButton.gameObject.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void AddScore(int addingScore)
    {
        score += addingScore;
        scoreText.text = "Score : " + score;
    }
}
