using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager Instance { get; private set; }
    public Color teamColor;
    //questo script verr� eseguito se: lo script � abilitato e quando l'instanza a esso associta verr� caricata 
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(Instance);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadColor();
    }

    [Serializable]
    class SaveData
    {
        public Color teamColor;
    }

    public void SaveColor()
    {
        SaveData saveData = new();
        saveData.teamColor = teamColor;
        string json = JsonUtility.ToJson(saveData);
        File.WriteAllText($"{Application.persistentDataPath}/savefile.json", json);
    }

    public void LoadColor()
    {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path))
        {
            string json = File.ReadAllText($"{Application.persistentDataPath}/savefile.json");
            var saveData = JsonUtility.FromJson<SaveData>(json);
            teamColor = saveData.teamColor;
        }
    }
}
