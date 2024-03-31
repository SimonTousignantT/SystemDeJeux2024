using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Achievements : MonoBehaviour
{
    [SerializeField]
    private Animator m_animator;
    [SerializeField]
    private ScriptableAchivements m_data;
    private DataSave m_dataSave;
    [SerializeField]
    private TextMeshProUGUI m_nameField;
    [SerializeField]
    private TextMeshProUGUI m_DescriptionField;
    // Start is called before the first frame update
    void Start()
    {
        m_dataSave = gameObject.GetComponent<DataSave>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            if(!m_dataSave.m_data.FistDiscoveryLvl1)
            {
                m_dataSave.m_data.FistDiscoveryLvl1 = true;
                AnimationEvent(0);
                
            }
        }
        if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (!m_dataSave.m_data.FistDiscoveryLvl2)
            {
                m_dataSave.m_data.FistDiscoveryLvl2 = true;
                AnimationEvent(1);
               
            }
        }
        if (SceneManager.GetActiveScene().name == "Level3")
        {
            if (!m_dataSave.m_data.FistDiscoveryLvl3)
            {
                m_dataSave.m_data.FistDiscoveryLvl3 = true;
                AnimationEvent(2);
                
            }
        }
        if(m_dataSave.m_data.lvl1kill == 3)
        {
            if (m_dataSave.m_data.lvl1kill == 6)
            {
                if (m_dataSave.m_data.lvl1kill == 9)
                {
                    if (!m_dataSave.m_data.FinishAllGame)
                    {
                        m_dataSave.m_data.FinishAllGame = true;
                        AnimationEvent(3);
                        
                    }
                }
            }
        }
    }
    private void AnimationEvent(int archivementNB)
    {
        m_dataSave.SaveData();
        m_nameField.text = m_data.m_archivements[archivementNB].Name;
        m_DescriptionField.text = m_data.m_archivements[archivementNB].Description;
        m_animator.SetTrigger("Play");
        
    }
    
}
