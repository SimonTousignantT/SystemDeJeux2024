using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowPool : MonoBehaviour
{
    [SerializeField]
    private GameObject m_arrowPrefab;
    private List<GameObject> m_arrowPool = new List<GameObject>();
    private GameObject m_myArrow;
    [SerializeField]
    private GameObject m_player;
    private List<GameObject> m_enemieList = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            m_myArrow = FindArrowInactiveInPool();
            m_myArrow.gameObject.SetActive(true);
            m_myArrow.transform.position = m_player.transform.position;
            m_myArrow.GetComponent<Arrow>().SetDirection();
        }
    }
    private GameObject FindArrowInactiveInPool()
    {
        foreach (GameObject Arrow in m_arrowPool)
        {
            if (!Arrow.gameObject.activeInHierarchy)
            {
                return Arrow;
            }
        }
        GameObject newArrow = Instantiate(m_arrowPrefab);
        newArrow.GetComponent<Arrow>().m_player = m_player;
        foreach (GameObject enemy in m_enemieList)
        {
            newArrow.GetComponent<Arrow>().SetEnemy(enemy);
        }
       
        m_arrowPool.Add(newArrow);
        return newArrow;
    }
    public void SetEnemy(GameObject enemy)
    {
        m_enemieList.Add(enemy);
    }
    public void RemoveEnemy(GameObject enemy)
    {
        m_enemieList.Remove(enemy);
        foreach(GameObject Arrow in m_arrowPool)
        {
            Arrow.GetComponent<Arrow>().RemoveEnemy(enemy);
        }
    }
}
