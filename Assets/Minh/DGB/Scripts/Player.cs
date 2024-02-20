using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float atkRate;
    private Animator m_anim;
    private float m_curAtkRate;
    private bool m_isAttacked;


    private void Awake()
    {
        m_anim = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //getmousebuttondown bấm chuột 0 là trái 1 là phải, getmousebutton dùng để dè check xem người chơi có giữ chuột
        if (Input.GetMouseButtonDown(0) && !m_isAttacked)
        {
            if (m_anim)
                m_anim.SetBool(Const.ATTACK_ANIM, true);
            m_isAttacked = true;
        }

        if (m_isAttacked)
        {
            m_curAtkRate -= Time.deltaTime;

            if(m_curAtkRate <= 0)
            {
                m_isAttacked = false;
                m_curAtkRate = atkRate;
            }
        }
    }

    

    public void ResetAtkAnim()
    {
        if (m_anim)
            m_anim.SetBool(Const.ATTACK_ANIM, false);
    }
}
