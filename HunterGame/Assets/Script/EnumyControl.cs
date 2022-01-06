using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumyControl : MonoBehaviour
{
    private float Speed;
    public int Hart;
    public int Dmg;
    private Animator Anime;
    private bool bWalk;
    private bool bAttack;
    private bool bDie;
    [Tooltip("공격쿨타임")]
    private float CoolTime;
    [Tooltip("현재 쿨타임")]
    private float CurTime;
    public Potal potal;
    private GameObject LifeObj;
    void Start()
    {
        Speed = 2.0f;
        CoolTime = 1.6f;
        Anime = GetComponent<Animator>();
        transform.Rotate(new Vector3(0, 180, 0));
        bWalk = true;
        bAttack = false;
        bDie = false;
        Hart = 400;
        Dmg = 50;
    }

    void Update()
    {
        if(bWalk == true)
            transform.Translate(Vector3.right * Speed * Time.deltaTime);


        Anime.SetBool("Walk", bWalk);
        Anime.SetBool("Attack", bAttack);
        Anime.SetBool("Die", bDie);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {       
        if (collision.transform.tag == "NomalBullet")
        {
            Anime.SetTrigger("Hurt");
           
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(CurTime <= 0)
        {
            if (collision.transform.tag == "Player")
            {
                bAttack = true;
                bWalk = false;
                // 충돌체의 오브젝트 불러오기
                GameObject Obj = collision.gameObject;
                
                // 오브젝트의 스크립트 불러오기
                PlayerManager.Getinstace.FindPlayer(Obj, Dmg);

            }
            else if (collision.transform.tag == "PlayerLife")
            {
                bAttack = true;
                bWalk = false;
                LifeObj = collision.gameObject;
                LifeObj.GetComponent<PlayerLife>().LifeDestroy();
            }
            CurTime = CoolTime;
        }
        else
        {
            CurTime -= Time.deltaTime;
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player" || collision.transform.tag == "PlayerLife")
        {
            bWalk = true;
            bAttack = false;
        }
    }
    public void Hit(int _Dmg)
    {
        // ** 체력이 0 이상일 때
        if (Hart > 0)
        {
            Hart -= _Dmg;
        }

        if (Hart <= 0)
        {
            bDie = true;
         //   bWalk = false;
            GameManager.GetInstance.KillCount++;
            

            if (GameManager.GetInstance.KillCount == GameManager.GetInstance.MaxZombiNumber)
            {
                UIManager UiObj = GameObject.Find("UiManager").GetComponent<UIManager>();
                UiObj.VictoryUiActive();
            }
        }
    }
}
