using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

[Serializable]

public class playerData
{
    public List<string> collectedItems = new List<string>();
    public int stage = 1;
}

public class GameDataManger : MonoBehaviour
{

    public static GameDataManger Instance;
    public playerData playerData;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject); // 중복방지
        }
    }



}

