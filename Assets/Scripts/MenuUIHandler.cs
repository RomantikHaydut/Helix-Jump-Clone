using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    GameManager gameManager;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI nameInputText;
    private void Awake()
    {
        Time.timeScale = 1;

    }
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.LoadNameAndScore();
        bestScoreText.text = "Best Score is : "+GameManager.bestScore+" by : "+GameManager.bestScoreOwner;

    }
    public void StartGame()
    {
        TakePlayerName();
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void TakePlayerName()
    {
        // Here we check player entered a name to input field. If there is no name we assign to activePlayerName "Player Unknown"
        if (nameInputText.text.Length == 1)
        {
            GameManager.activePlayerName = "Player Unknown";
        }
        else
        {
            GameManager.activePlayerName = nameInputText.text;
        }

    }

    public void ResetBestScore()
    {
        gameManager.SaveNameAndScore("-", 0);
        gameManager.LoadNameAndScore();
        bestScoreText.text = "Best Score is : " + GameManager.bestScore + " by : " + GameManager.bestScoreOwner;
    }
}
