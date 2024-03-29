using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class KillCount : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI m_killCountUI;
    private string m_killText;
    private int m_killCount = 0;
    [SerializeField]
    private int m_MonsterNeed = 3;
    // Start is called before the first frame update
    void Start()
    {
        m_killText = "monster kill " + m_killCount + "/" + m_MonsterNeed + "          bronze = 1, silver = 2, gold = 3";
    }

    // Update is called once per frame
    void Update()
    {
        m_killCountUI.text = m_killText;
    }
    public void killAdd()
    {
        m_killCount++;
        m_killText = "monster kill " + m_killCount + "/" + m_MonsterNeed + "          bronze = 1, silver = 2, gold = 3";
    }
}
