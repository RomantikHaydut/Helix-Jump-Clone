using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{
    GameManager gameManager;
    public TextMeshProUGUI bestScoreText;
    public TextMeshProUGUI nameInputText;
    private Button sensitivityButton;
    private void Awake()
    {
        Time.timeScale = 1;

    }
    private void Start()
    {
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        gameManager.LoadNameAndScore();
        bestScoreText.text = "Best Score is : "+GameManager.bestScore+" by : "+GameManager.bestScoreOwner;

        SelectSavedSensitivity();
        

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

    public void TakeSensitivity(float sensitive)
    {
        gameManager.SaveSensitivy(sensitive);
        gameManager.LoadSensitivity();
    }

    public void SelectSavedSensitivity()
    {
        // Here we select the button which is we select before.
        gameManager.LoadSensitivity();
        if (GameManager.activeSensitivity == 100)
        {
            sensitivityButton = GameObject.Find("Sensitivy 1").GetComponent<Button>();
            sensitivityButton.Select();
        }
        else if (GameManager.activeSensitivity == 140)
        {
            sensitivityButton = GameObject.Find("Sensitivy 2").GetComponent<Button>();
            sensitivityButton.Select();


        }
        else if (GameManager.activeSensitivity == 180)
        {
            sensitivityButton = GameObject.Find("Sensitivy 3").GetComponent<Button>();
            sensitivityButton.Select();

        }
    }
}
