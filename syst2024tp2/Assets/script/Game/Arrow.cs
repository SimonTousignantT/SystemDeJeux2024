using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    [SerializeField]
    private float timeAlive = 10;
    private List<GameObject> m_monsterList = new List<GameObject>();
    public GameObject m_player;
    private GameObject m_EnemyDetected;
  
    private IEnumerator ArrowDestroyer()
    {
        yield return new WaitForSeconds(timeAlive);
        gameObject.SetActive(false);
    }
    public void SetEnemy(GameObject enemy)
    {
        m_monsterList.Add(enemy);
    }
    public void RemoveEnemy(GameObject enemy)
    {
        m_monsterList.Remove(enemy);
    }
    public void SetDirection()
    {
        StartCoroutine(ArrowDestroyer());
        m_EnemyDetected = m_monsterList[0];
        gameObject.transform.forward = (gameObject.transform.position - m_EnemyDetected.transform.position) * -1;
    }
}
