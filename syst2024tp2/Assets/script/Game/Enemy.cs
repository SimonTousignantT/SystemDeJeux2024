using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    [SerializeField]
    AudioClip m_axeSlashSound;
    [SerializeField]
    AudioPool m_audioPool;
    [SerializeField]
    AudioClip m_growlSound;
    [SerializeField]
    private GameObject m_player;
    [SerializeField]
    private float m_distanceAgro = 10;
    [SerializeField]
    private float m_distanceAttack = 3;
    public bool m_onAttack = false;
    private float m_maxLife = 100;
    private float m_life;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeDamage());
        m_life = m_maxLife;
        m_player.GetComponent<PlayerControl>().SetEnemy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
       
        if (Vector3.Distance(gameObject.transform.position, m_player.transform.position) < m_distanceAgro)
        {
            gameObject.GetComponent<NavMeshAgent>().SetDestination(m_player.transform.position);
            gameObject.GetComponent<Animator>().SetBool("Attack", false);
            gameObject.GetComponent<Animator>().SetBool("Walk", true);
            gameObject.transform.forward = (gameObject.transform.position - m_player.transform.position)*-1 ;
            
        }
        if (Vector3.Distance(gameObject.transform.position, m_player.transform.position) < m_distanceAttack)
        {
            //Debug.Log("enemy attack");
            gameObject.GetComponent<Animator>().SetBool("Attack", true);
            gameObject.GetComponent<Animator>().SetBool("Walk", false);
            m_onAttack = true;
        }
        else
        {
            m_onAttack = false;
        }
        if (Vector3.Distance(gameObject.transform.position, m_player.transform.position) < 1)
        {
            gameObject.transform.position += gameObject.transform.forward * -1;
        }
    }
    private IEnumerator MakeDamage()
    {
        while(true)
        {
            if(m_onAttack)
            {
                yield return new WaitForSeconds(0.542f);
                
                if (m_onAttack)
                {
                    //Debug.Log("envoie les degas");
                    m_player.GetComponent<Life>().SetDamageToPlayer(7);
                    m_audioPool.PlayMusicPool(m_axeSlashSound);
                }
                yield return new WaitForSeconds(1);
            }
            
            yield return new WaitForEndOfFrame();
        }
    }
    public void SetDamagelifeEnemy(float damage)
    {
        Debug.Log("Getdamage");
        m_audioPool.PlayMusicPool(m_growlSound);
        m_life -= damage;
        if(m_life <= 0)
        {
            m_player.GetComponent<PlayerControl>().RemoveEnemy(this.gameObject);
            gameObject.GetComponent<Animator>().SetTrigger("Death");
            m_player.GetComponent<KillCount>().killAdd();
            Destroy(this);
        }
    }
   
}
