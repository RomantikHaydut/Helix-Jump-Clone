using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainManager : MonoBehaviour
{
    public Button pauseButton;
    public Button continueButton;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
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
}
