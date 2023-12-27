using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static MainManager instance;
    public Color teamColor;
    //questo script verrà eseguito se: lo script è abilitato e quando l'instanza a esso associta verrà caricata 
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
            return;
        }
        instance = this;
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
