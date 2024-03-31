using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class LvlFinishText : MonoBehaviour
{
    [SerializeField]
    DataSave m_data;
    // Start is called before the first frame update
    void Start()
    {
        m_data.LoadLvlData();
    }

    // Update is called once per frame
    void Update()
    {
      
            gameObject.GetComponent<TextMeshProUGUI>().text = "you have find" + m_data.m_data.lvlScore + "/" + m_data.m_data.LastLvl*3 +" monster";
    }
}
