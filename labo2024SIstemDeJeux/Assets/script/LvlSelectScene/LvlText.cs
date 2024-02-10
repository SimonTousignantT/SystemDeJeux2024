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
    private List<string> m_pagestxt = new List<string>();
    private int m_Page = 0;
    private int m_PageNB;
    private bool m_firstTime = true;
    string m_txt = "";
    // Start is called before the first frame update

    public void ButtonNextText()
    {
        Debug.Log("le bouton a ete click");
        Debug.Log(m_Page + " / "+m_PageNB );
        if (m_Page < m_PageNB - 1)
        {
            Debug.Log("demade tafficher la prochaine page");
            m_Page += 1;

            starCouroutine();
        }
        
        
    }
    private IEnumerator TxtShow()
    {
       
        //Debug.Log("sa entre dans la couroutine" + m_pagestxt.Count);
        
        foreach (char Char in m_pagestxt[m_Page])
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
                m_pagestxt.Add(data.page);
            }
            m_PageNB = m_pagestxt.Count;
            m_firstTime = false;
            
        }
        //Debug.Log("la couroutine est appeler");
        m_Page = 0;
        starCouroutine();



    }
    public void starCouroutine()
    {
        StopCoroutine(TxtShow());
        m_txt = "";
        StartCoroutine(TxtShow());
    }

}
