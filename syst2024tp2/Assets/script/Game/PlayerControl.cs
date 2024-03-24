using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    
    private float m_velocityX;
    private float m_velocityY;
    private float m_velocityZ;
    [SerializeField]
    private float m_walkSpeed = 3;
    private float m_speed = 3;
    [SerializeField]
    private float m_runSpeed = 7;
    [SerializeField]
    private float m_jumpforce = 5;
    [SerializeField]
    private float m_speedRotateX = 0.5f;
    [SerializeField]
    private float m_offsetRotation = 75;
    [SerializeField]
    private Animator m_myAnimator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        rotate();
        
    }

    private void rotate()
    {
        
        if(Input.mousePosition.x > Screen.width/2 + m_offsetRotation)
        {
            gameObject.transform.Rotate(0, m_speedRotateX, 0 , Space.Self);
        }
        if (Input.mousePosition.x < Screen.width / 2 - m_offsetRotation)
        {
            gameObject.transform.Rotate(0, m_speedRotateX * -1, 0, Space.Self);
        }
    }

    private void Move()
    {
        m_myAnimator.SetBool("WalkZ+", false);
        m_myAnimator.SetBool("WalkZ-", false);
        m_myAnimator.SetBool("WalkX+", false);
        m_myAnimator.SetBool("WalkX-", false);
        m_myAnimator.SetBool("Jump", false);
        ////gere la vitesse si il est entrain de courir ou pas
        if (Input.GetKey(KeyCode.LeftShift))
        {
            m_speed = m_runSpeed;
        }
        else
        {
            m_speed = m_walkSpeed;
        }
       
        ////////// gere la velocyté en Z+
        m_velocityZ = 0;
        if (Input.GetKey(KeyCode.W))
        {
            m_velocityZ += m_speed;
            if (m_velocityZ > m_speed)
            {
                m_velocityZ = m_speed;
            }
            m_myAnimator.SetBool("WalkZ+", true);
        }
       
        ///////////////gere la velocyté en X
        if (Input.GetKey(KeyCode.A))
        {
            m_speed = m_walkSpeed;
            m_velocityX -= m_speed;
            if (m_velocityX < m_speed)
            {
                m_velocityX = m_speed * -1;
            }
            m_myAnimator.SetBool("WalkX-", true);
            m_myAnimator.SetBool("WalkZ+", false);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            m_speed = m_walkSpeed;
            m_velocityX += m_speed;
            if (m_velocityX > m_speed)
            {
                m_velocityX = m_speed;
            }
            m_myAnimator.SetBool("WalkX+", true);
            m_myAnimator.SetBool("WalkZ+", false);
        }
        else
        {
            m_velocityX = 0;
        }
        ////////// gere la velocyté en Z-
        if (Input.GetKey(KeyCode.S))
        {
            m_speed = m_walkSpeed;
            m_velocityZ -= m_speed;
            if (m_velocityZ < m_speed)
            {
                m_velocityZ = m_speed * -1;
            }
            
            m_myAnimator.SetBool("WalkZ-", true);
            m_myAnimator.SetBool("WalkX-", false);
            m_myAnimator.SetBool("WalkX+", false);

        }
        
       
        gameObject.GetComponent<Rigidbody>().velocity = transform.right * m_velocityX + transform.forward * m_velocityZ + new Vector3(0, m_velocityY, 0);
    }
   
}
