using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ResultManager : MonoBehaviour
{
    // Start() and Update() methods deleted - we don't need them right now

    public static ResultManager Instance;

    public string highScorePlayerName; // new variable declared
    public int highScore;
    public string currentPlayerName;

    private void Awake()
    {
        // start of new code
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        // end of new code
        Instance = this;
        DontDestroyOnLoad(gameObject);

        LoadScore();
    }

    [System.Serializable]
    class SaveData
    {
        public string playerName;
        public int score;
    }

    public void SaveScore()
    {
        SaveData data = new SaveData();
        data.playerName = highScorePlayerName;
        data.score = highScore;

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadScore()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScorePlayerName = data.playerName;
            highScore = data.score;
        }
    }
}
