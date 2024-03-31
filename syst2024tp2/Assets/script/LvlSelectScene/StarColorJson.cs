using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StarColorJson : MonoBehaviour
{
    [SerializeField]
    DataSave m_data;
    [SerializeField]
    private List<SpriteRenderer> m_star;
    [SerializeField]
    ScriptableText m_scriptableObject;
    // Start is called before the first frame update
    void Start()
    {
        m_data.LoadLvlData();
        
        if(m_data.m_data.lvl1kill >= 1)
        {
            m_star[0].color = m_scriptableObject.Bronze;
        }
        if (m_data.m_data.lvl1kill >= 2)
        {
            m_star[0].color = m_scriptableObject.argent;
        }
        if (m_data.m_data.lvl1kill >= 3)
        {
            m_star[0].color = m_scriptableObject.or;
        }
        ///////////////
        if (m_data.m_data.lvl2kill >= 2)
        {
            m_star[1].color = m_scriptableObject.Bronze;
            
        }
        if (m_data.m_data.lvl2kill >= 4)
        {
            m_star[1].color = m_scriptableObject.argent;
        }
        if (m_data.m_data.lvl2kill >= 6)
        {
            m_star[1].color = m_scriptableObject.or;

        }
        ////////////////
        if (m_data.m_data.lvl3kill >= 3)
        {
            m_star[2].color = m_scriptableObject.Bronze;
        }
        if (m_data.m_data.lvl3kill >= 6)
        {
            m_star[2].color = m_scriptableObject.argent;
        }
        if (m_data.m_data.lvl3kill >= 9)
        {
            m_star[2].color = m_scriptableObject.or;
        }
    }

   
}
