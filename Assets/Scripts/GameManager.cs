using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static int bestScore;
    public static GameManager gameManager;

    private void Awake()
    {
        // Here we made GameManager object singleton.
        // Here we check is gameManager null ? and in the beginning it is null so program wont read inside of if statement.
        if (gameManager!=null) 
        {
            Destroy(gameObject);

        }
        else   // Here the first opening gameManager is null and we make it our class.
        {
            gameManager = this;
        }
        // Here we made gameManager can't destroyable , so when we open first scene program will read first if statement and it will destroy the spawning game manager.
        // Our game manager wont be destroyed because of awake method will not work again for it.
        // So our first game manager is singleton now.
        DontDestroyOnLoad(gameManager);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartGame();
        }
        else if (Input.GetKeyDown(KeyCode.M))
        {
            GoMenu();
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoMenu()
    {
        SceneManager.LoadScene(0);

    }
}
