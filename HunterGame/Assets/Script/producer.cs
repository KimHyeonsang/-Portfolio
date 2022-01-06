using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class producer : MonoBehaviour
{
    public GameObject RemoveObject;

    [SerializeField] private GameObject Coin;
    [Tooltip("������Ÿ��")]
    private float CoolTime;
    [Tooltip("���� ��Ÿ��")]
    private float CurTime;

   
    void Start()
    {
        CoolTime = Random.Range(5,11);
        Coin = Resources.Load("Frefabs/Coin") as GameObject;
        CurTime = CoolTime;
    }

    void Update()
    {
        // 5~10�� ���̷� ������ ����
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
        // ** ü���� 0 �̻��� ��
        if (ProducerInfo.Hart > 0)
        {
            ProducerInfo.Hart -= _Dmg;
        }
        
        if(ProducerInfo.Hart <= 0)
        {
            // ** ���� ������Ʈ Ȱ��ȭ
            RemoveObject.SetActive(true);
            Destroy(gameObject);
        }
    }
}