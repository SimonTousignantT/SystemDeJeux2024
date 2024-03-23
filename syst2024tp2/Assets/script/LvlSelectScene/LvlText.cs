using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static ScriptableText;

public class LvlText : MonoBehaviour
{

    public ScriptableText m_scriptableData;
    [SerializeField]
    private GameObject m_textZone;
    private List<string> m_pagesTxt = new List<string>();
    private int m_page = 0;
    private int m_pageNB;
    private bool m_firstTime = true;
    private string m_txt = "";
    [SerializeField]
    private GameObject m_NameLevelZone;
   

    // Start is called before the first frame update
    
    public void ButtonNextText()
    {
        Debug.Log("le bouton a ete click");
        Debug.Log(m_page + " / "+m_pageNB );
        if (m_page < m_pageNB - 1)
        {
            Debug.Log("demade tafficher la prochaine page");
            m_page += 1;

            StarCouroutine();
        }
        
        
    }
    private IEnumerator TxtShow()
    {

        //Debug.Log("sa entre dans la couroutine" + m_pagestxt.Count);

        //Debug.Log(m_NameLevelZone.name);
        m_NameLevelZone.GetComponent<TextMeshPro>().SetText(m_scriptableData.LvlName);
        foreach (char Char in m_pagesTxt[m_page])
        {
            
            m_txt += Char;
            //Debug.Log("sa entre dans le foreach");
            m_textZone.GetComponent<TextMeshPro>().SetText(m_txt);
            //Debug.Log("sa edit le text");
            yield return new WaitForSeconds(0.2f);
        }
        

    }
    
    private void OnEnable()
    {
        
        if(m_firstTime)
        {
            foreach (PageData data in m_scriptableData.DataPage)
            {
                m_pagesTxt.Add(data.page);
            }
            m_pageNB = m_pagesTxt.Count;
            m_firstTime = false;
            
        }
        //Debug.Log("la couroutine est appeler");
        m_page = 0;
        StarCouroutine();
        /////
      

    }
    public void StarCouroutine()
    {
        StopAllCoroutines();
        m_txt = "";
        StartCoroutine(TxtShow());
    }

}
