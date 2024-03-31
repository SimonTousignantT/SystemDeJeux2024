using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Life : MonoBehaviour
{
    [SerializeField]
    private float m_maxLife = 100;
    private float m_life;
    [SerializeField]
    private Image m_lifeBar;
    // Start is called before the first frame update
    void Start()
    {
        m_life = m_maxLife;
    }

    // Update is called once per frame
    void Update()
    {
        m_lifeBar.fillAmount = m_life / m_maxLife;
    }
    public void SetDamageToPlayer(float damage)
    {
        m_life -= damage;
        if(m_life <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }
    }
}
