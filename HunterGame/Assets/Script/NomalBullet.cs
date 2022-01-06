using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBullet : MonoBehaviour
{
    private float Speed;
    private int Dmg;
    private GameObject Target;
    private bool life;

    public GameObject m_Effect;
    void Start()
    {
        Speed = 10.0f;
        
    }

    void Update()
    {
        if(Target.GetComponent<EnumyControl>().Hart <= 0)
        {
            Destroy(gameObject);
            Destroy(Target,2.0f);
        }
        else
        {
            Vector3 vec = Target.transform.position - transform.position;
            vec.Normalize();

            transform.Translate(vec * Speed * Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Target")
        {
            //데미지
            Target.GetComponent<EnumyControl>().Hit(Dmg);
            //총알 삭제
            Destroy(gameObject);
        }
    }

    public void TargetPosition(GameObject _Obj,int _Dmg)
    {
        Target = _Obj;
        Dmg = _Dmg;
    }
}
