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
        bestScoreText.text = "Best Score is : "+GameManager.bestScore+" by "+GameManager.bestScoreOwner;

    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void TakePlayerName()
    {
        GameManager.activePlayerName=nameInputText.text;
    }
}
