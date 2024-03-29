using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Life : MonoBehaviour
{
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
    }
}
