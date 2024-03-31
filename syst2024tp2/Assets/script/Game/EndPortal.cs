using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class EndPortal : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;
    private void OnCollisionEnter(Collision collision)
    {
        m_player.GetComponent<KillCount>().SaveData();
        SceneManager.LoadScene("LvlFinish");
    }
    
}
