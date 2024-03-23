using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonLvlStart : MonoBehaviour
{
    private Action<string> m_startLvl;
   
    // Start is called before the first frame update
    void Start()
    {
        m_startLvl = LvlStart;
    }

    // Update is called once per frame
   public void LvlStart(string Lvl)
    {
        SceneManager.LoadScene(Lvl);
    }
    public void ButtonLvl1()
    {
        m_startLvl("Level1");
    }
    public void ButtonLvl2()
    {
        m_startLvl("Level2");
    }
    public void ButtonLvl3()
    {
        m_startLvl("Level3");
    }

}
