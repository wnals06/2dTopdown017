using UnityEngine;
using System.Collections.Generic;
using System.IO;

[System.Serializable]
public class PlayerData
{
    public int coins = 0;
    public int experience = 0;
    public List<string> unlockedCharacters = new List<string>();
    public int highScore = 0;
}

public class GameDataManager : MonoBehaviour
{
    public static GameDataManager Instance;
    public PlayerData playerData;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadPlayerData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void SavePlayerData()
    {
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(Application.persistentDataPath + "/playerdata.json", json);
    }

    public void LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/playerdata.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            playerData = JsonUtility.FromJson<PlayerData>(json);
        }
        else
        {
            playerData = new PlayerData();
        }
    }

    public void OnPlayerDeath()
    {
        SavePlayerData();
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
    }
}

