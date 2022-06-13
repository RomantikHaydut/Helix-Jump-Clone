using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.IO;

public class GameManager : MonoBehaviour
{
    public static int bestScore;
    public static string bestScoreOwner;
    public static string activePlayerName;
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

 

    [System.Serializable]
    public class SaveData
    {
        // Here we made a new class as SaveData and decleared 2 variables for best score and its owner.
        public string playerName;
        public int score;
    }

    public void SaveNameAndScore(string player,int score) 
    {
        // Here we define SaveData class like data and when we want to use this method we can access playerName and score with player and best score variables.
        SaveData data = new SaveData();

        data.playerName = player;
        data.score = score;

        // Here we change our data format to .json format.
        string json = JsonUtility.ToJson(data);

        // Here need use File need System.IO library.
        // And we WritedAllText to application.persistentDataPath pathway + savefile.json we writed "json" 
        File.WriteAllText(Application.persistentDataPath+"savefile.json", json);

    }

    public void LoadNameAndScore()
    {
        // Here we define pathway where we save datas. And we check is there a savefile ?.
        string path = Application.persistentDataPath + "savefile.json";
        if (File.Exists(path))
        {
            // And here we are reading our text in path and we define them as json string format.
            // And we define our SaveData class here again.
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);   // Look here again !!!!!!!!!!!!!!!!!!!!

            // Here we assign our variables from variables from data class.
            bestScoreOwner = data.playerName;
            bestScore = data.score;

        }


    }


}
