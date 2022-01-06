using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attacker : MonoBehaviour
{    
    //  ** 삭제 시킨 오브젝트 저장
    private GameObject RemoveObject;
    private GameObject BulletObj;

    public float ShortDis;
    private bool bShort;

    [Tooltip("공격쿨타임")]
    private float CoolTime;
    [Tooltip("현재 쿨타임")]
    private float CurTime;
    void Start()
    {
        bShort = false;
        CoolTime = 3.0f;
        BulletObj = Resources.Load("Frefabs/NomalBullet") as GameObject;
    }
    void Update()
    {
        // 타겟이라는 오브젝트 모두 검색
        GameObject[] Target = GameObject.FindGameObjectsWithTag("Target");


        for(int i = 0;i < Target.Length; ++i )
        {
            // 만약 y축의 위치가 같을 경우
            if(transform.position.y  == Target[i].transform.position.y)
            {
                if (CurTime <= 0)
                {
                    // 프리팹에서 생성
                    GameObject Obj = Instantiate(BulletObj);
                    // 위치 조절
                    Obj.transform.position = new Vector3(transform.position.x + 2, transform.position.y - 1, transform.position.z);

                    // 타겟 위치 저장
                    Obj.GetComponent<NomalBullet>().TargetPosition(Target[i], AttackerInfo.Attack);

                    CurTime = CoolTime;
                }
                else
                {
                    CurTime -= Time.deltaTime;
                }

                // 거리 측정
                float Distance = Vector2.Distance(transform.position, Target[i].transform.position);

                // 만약 짧은것이 없으면
                if(bShort == false)
                {
                    ShortDis = Distance;
                    bShort = true;
                }

                // 측정한 거리가 짧은것보다 작을 경우
                if (Distance < ShortDis)
                {
                    ShortDis = Distance;
                }
            }

        }

    }

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
        if (AttackerInfo.Hart > 0)
        {
            AttackerInfo.Hart -= _Dmg;
        }

        if (AttackerInfo.Hart <= 0)
        {
            // ** 지운 오브젝트 활성화
            RemoveObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
