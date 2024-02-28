using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowUIRange : MonoBehaviour
{
    [SerializeField]
    private GameObject m_player;
    [SerializeField]
    private GameObject m_scrollCanvas;
    [SerializeField]
    private GameObject m_allPortal;
    private List<GameObject> m_scrollList = new List<GameObject>();
    private List<GameObject> m_portalList = new List<GameObject>();
    private int m_scrollNB;
    private int m_portalNB;
    [SerializeField]
    private float m_distanceToShow = 1.5f;
    [SerializeField]
    private float m_chronosToShow = 2;
    private GameObject m_parchemin;
    [SerializeField]
    GameObject m_eventManager;
    
    // Start is called before the first frame update
    void Start()
    {
        FindScrollElementUI();
        FindAllPortal();


    }

    // Update is called once per frame
    void Update()
    {
        DistanceToShow();
    }
 
    private void ScrollElementToShow(GameObject Scroll,bool Active)
    {
        
        //Debug.Log(Scroll.name + "sa entré dans le scoll element to show");
        int ScrollElementNB = Scroll.transform.childCount;
        List<GameObject> ScrollElementList = new List<GameObject>();
        while (ScrollElementNB > 0)
        {
            ScrollElementNB--;
            ScrollElementList.Add(Scroll.transform.GetChild(ScrollElementNB).gameObject);
            ///Debug.Log("ADD   " + Scroll.transform.GetChild(ScrollElementNB).gameObject.name);
        }
        //Debug.Log(Scroll.name + "sa passer le while");
        if (Active)
        {
            
            ///Debug.Log("un element du UI doit etre activé");
            foreach (GameObject ScrollElement in ScrollElementList)
            {
                //Debug.Log("ChekName//" + ScrollElement.gameObject.name + "//");
                if (ScrollElement.gameObject.name == "Parchemin")/// dafuq il ne reconnai pas le nom whys???? ############################ Ereur!! resolue il y avait un espace a la fin du nom
                {
                   // Debug.Log("Parchemin activation ");
                    ScrollElement.SetActive(true);
                    
                    // Debug.Log("ChekName//" + ScrollElement.gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name + "//");
                    if (ScrollElement.gameObject.GetComponent<Animator>().GetCurrentAnimatorClipInfo(0)[0].clip.name == "ParcheminFin")
                    {
                        //Debug.Log("le parchemin est a sa derniere animation");
                        foreach (GameObject OtherScrollElement in ScrollElementList)
                        {
                            //Debug.Log("jactive tout les autre component");
                            OtherScrollElement.SetActive(true);
                            
                            
                        }
                    }
                }
            }

        }
        else
        {
            foreach (GameObject ScrollElement in ScrollElementList)
            {
                
                ScrollElement.SetActive(false);
                
            }
        }
        
    }
   
    private void DistanceToShow()
    {
        int PortalNB = m_portalList.Count;
        //Debug.Log(PortalNB);
        while (PortalNB > 0)
        {
            PortalNB--;
           // Debug.Log(PortalNB);
            if (Vector2.Distance(m_player.transform.position, m_portalList[PortalNB].gameObject.transform.position)< m_distanceToShow)
            {
                
                ScrollElementToShow(m_scrollList[PortalNB],true);
                
            }
            else
            {
                ScrollElementToShow(m_scrollList[PortalNB], false);
            }

        }
    }
    private void FindScrollElementUI()
    {
        m_scrollNB = m_scrollCanvas.transform.childCount;
        //Debug.Log(m_scrollNB);
        while (m_scrollNB > 0)
        {
            m_scrollNB--;
            m_scrollList.Add(m_scrollCanvas.transform.GetChild(m_scrollNB).gameObject);
            //Debug.Log("add" + m_scrollCanvas.transform.GetChild(m_scrollNB).gameObject.name);
        }
    }

    private void FindAllPortal()
    {
        m_portalNB = m_allPortal.transform.childCount;
        //Debug.Log(m_portalNB);
        while (m_portalNB > 0)
        {
            m_portalNB--;
            m_portalList.Add(m_allPortal.transform.GetChild(m_portalNB).gameObject);
            //Debug.Log("add" + m_allPortal.transform.GetChild(m_portalNB).gameObject.name);
        }
    }
}
