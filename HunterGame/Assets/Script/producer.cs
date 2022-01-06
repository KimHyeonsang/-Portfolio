using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class producer : MonoBehaviour
{
    public GameObject RemoveObject;

    [SerializeField] private GameObject Coin;
    [Tooltip("생산쿨타임")]
    private float CoolTime;
    [Tooltip("현재 쿨타임")]
    private float CurTime;

   
    void Start()
    {
        CoolTime = Random.Range(5,11);
        Coin = Resources.Load("Frefabs/Coin") as GameObject;
        CurTime = CoolTime;
    }

    void Update()
    {
        // 5~10초 사이로 코인을 생산
        if (CurTime <= 0)
        {
            GameObject CoinObj = Instantiate(Coin);

            CoinObj.transform.position = new Vector3(transform.position.x,transform.position.y,-10.0f);
            CoolTime = Random.Range(5, 8);
            GameManager.GetInstance.CoinList.Add(CoinObj);
            CurTime = CoolTime;
        }
        else
        {
            CurTime -= Time.deltaTime;
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
        if (ProducerInfo.Hart > 0)
        {
            ProducerInfo.Hart -= _Dmg;
        }
        
        if(ProducerInfo.Hart <= 0)
        {
            // ** 지운 오브젝트 활성화
            RemoveObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}
