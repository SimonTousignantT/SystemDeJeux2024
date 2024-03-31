using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class KillCount : MonoBehaviour
{
    [SerializeField]
    private int m_lvl;
    [SerializeField]
    private TextMeshProUGUI m_killCountUI;
    private string m_killText;
    private int m_killCount = 0;
    [SerializeField]
    private int m_MonsterNeed = 3;
    [SerializeField]
    private DataSave m_dataSave;
    [SerializeField]
    private List<string> m_textObjectif;
    // Start is called before the first frame update
    void Start()
    {
        m_killText = "monster kill " + m_killCount + "/" + m_MonsterNeed + m_textObjectif[m_lvl - 1];
    }

    // Update is called once per frame
    void Update()
    {
        m_killCountUI.text = m_killText;
    }
    public void killAdd()
    {
        m_killCount++;
        m_killText = "monster kill " + m_killCount + "/" + m_MonsterNeed + m_textObjectif[m_lvl - 1];
    }
    public void SaveData()
    {
        m_dataSave.LoadLvlData();
        if (m_lvl == 1)
        {
            if(m_dataSave.m_data.lvl1kill < m_killCount)
            { m_dataSave.m_data.lvl1kill = m_killCount; }
           
        }
        if (m_lvl == 2)
        {
            if (m_dataSave.m_data.lvl2kill < m_killCount)
            { m_dataSave.m_data.lvl2kill = m_killCount; }
               
        }
        if (m_lvl == 3)
        {
            if (m_dataSave.m_data.lvl3kill < m_killCount)
            { m_dataSave.m_data.lvl3kill = m_killCount; }
               
        }
        m_dataSave.m_data.LastLvl = m_lvl;
        m_dataSave.m_data.lvlScore = m_killCount;
        m_dataSave.SaveData();
    }
}
