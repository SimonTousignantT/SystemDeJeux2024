using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataSave : MonoBehaviour
{
    
    private int m_monsterKill;
    [SerializeField]
    public ClassSave m_data = new ClassSave();
    private string m_saveFilePath ;
    private void Start()
    {
        m_saveFilePath = Application.persistentDataPath + "/LvlData.json";
    }
    public void LoadLvlData()
    {
       
        if (File.Exists(m_saveFilePath))
        {
            
            string loadPlayerData = File.ReadAllText(m_saveFilePath);
            JsonUtility.FromJsonOverwrite(loadPlayerData, m_data);

        }
    }

    public void DeleteSaveFile()
    {
      
        if (File.Exists(m_saveFilePath))
        {
            File.Delete(m_saveFilePath);
        }
    }
    public void SaveData()
    {
       
        string savePlayerData = JsonUtility.ToJson(m_data);
        File.WriteAllText(m_saveFilePath, savePlayerData);
    }
}


