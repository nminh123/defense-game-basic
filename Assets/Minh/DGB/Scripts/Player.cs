using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace nminh.DGB
{
    public class Player : MonoBehaviour, IcomponentChecking
    {
        public float atkRate;
        private Animator m_anim;
        private float m_curAtkRate;
        private bool m_isAttacked;
        private bool m_isDead;

        private void Awake()
        {
            m_anim = GetComponent<Animator>();
        }


        // Start is called before the first frame update
        void Start()
        {

        }


        public bool IsComponentsNull()
        {
            return m_anim == null;
        }


        // Update is called once per frame
        void Update()
        {
            if (IsComponentsNull()) return;
            //getmousebuttondown bấm chuột 0 là trái 1 là phải, getmousebutton dùng để dè check xem người chơi có giữ chuột
            if (Input.GetMouseButtonDown(0) && !m_isAttacked)
            {
                
                   m_anim.SetBool(Const.ATTACK_ANIM, true);
                   m_isAttacked = true;
            }

            if (m_isAttacked)
            {
                m_curAtkRate -= Time.deltaTime;

                if (m_curAtkRate <= 0)
                {
                    m_isAttacked = false;
                    m_curAtkRate = atkRate;
                }
            }
        }



        public void ResetAtkAnim()
        {
            if (IsComponentsNull()) return;
                m_anim.SetBool(Const.ATTACK_ANIM, false);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (IsComponentsNull()) return;

            if (col.CompareTag(Const.ENEMY_WEAPON_TAG) && !m_isDead)
            {
                m_anim.SetTrigger(Const.DEAD_ANIM);
                m_isDead = true;
            }
        }
    }
}

