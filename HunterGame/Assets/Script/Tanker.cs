using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tanker : MonoBehaviour
{
    //  ** 삭제 시킨 오브젝트 저장
    public GameObject RemoveObject;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "PlayerSpawn")
        {
            GameObject[] Obj = GameObject.FindGameObjectsWithTag("PlayerSpawn");

            for (int i = 0; i < Obj.Length; ++i)
            {
                if (Obj[i].transform.position == collision.transform.position)
                {
                    RemoveObject = Obj[i];
                    Obj[i].SetActive(false);
                }
            }
        }
    }

    public void Hit(int _Dmg)
    {
        // ** 체력이 0 이상일 때
        if (TankerInfo.Hart > 0)
        {
            TankerInfo.Hart -= _Dmg;
        }

        if (TankerInfo.Hart <= 0)
        {
            // ** 지운 오브젝트 활성화
            RemoveObject.SetActive(true);
            Destroy(gameObject);
        }

    }
}
