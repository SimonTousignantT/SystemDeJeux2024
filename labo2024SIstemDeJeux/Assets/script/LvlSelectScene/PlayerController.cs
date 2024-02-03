using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float m_PlayerSpeed = 5;
    private float m_velocityX ;
    private float m_velocytyY ;
    private bool m_orientationFaceRight = true;
    [SerializeField]
    private Animator m_animator;
    private bool m_detectMultyKey;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        m_detectMultyKey = false;
        AnimationRun(false);
        m_velocytyY = gameObject.GetComponent<Rigidbody2D>().velocity.y;
        m_velocityX = 0;
        if(Input.GetKey(KeyCode.D))
        {
            m_velocityX += m_PlayerSpeed;
            m_orientationFaceRight = true;
            AnimationRun(true);
            m_detectMultyKey = true;
        }
        if (Input.GetKey(KeyCode.A))
        {
            m_velocityX -= m_PlayerSpeed;
            m_orientationFaceRight = false;
            AnimationRun(true);
            if(m_detectMultyKey)
            {
                AnimationRun(false);
            }
        }
        gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(m_velocityX, m_velocytyY);
        Orientation();


    }
    private void Orientation()
    {
        if (m_orientationFaceRight == true)
        {
            if(gameObject.transform.localScale.x < 0)
            {
                gameObject.transform.localScale = gameObject.transform.localScale * new Vector2(-1,1);
            }
            
        }
        else
        {
            if (gameObject.transform.localScale.x > 0)
            {
                gameObject.transform.localScale = gameObject.transform.localScale * new Vector2(-1, 1);
            }
        }
    }
    private void AnimationRun(bool run)
    {
        if(run)
        {
            m_animator.SetBool("Move", true);
        }
        else
        {
            m_animator.SetBool("Move", false);
        }
    }
    
}
