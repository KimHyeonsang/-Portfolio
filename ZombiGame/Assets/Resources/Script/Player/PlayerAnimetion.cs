using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimetion : MonoBehaviour
{
    private Animator Anim;

    private bool JumpCheck;
    private bool Runing;
    private bool Reroad;

    private CloseWeapon currentWeapon;
    private PlayerContorl PlayerCrl;
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        PlayerCrl = GetComponent<PlayerContorl>();

        
    }
    void Start()
    {
        JumpCheck = false;
        Runing = false;
        Reroad = false;

        // �÷��̾�
   //     currentWeapon = PlayerCrl.CurrentWeapon.transform.GetChild(PlayerCrl.CurrentWeaponNumber).GetComponent<CloseWeapon>();
    }

    void Update()
    {
        // �÷��̾ ���� ����ִ� ���� ������ �޾ƿ´�
        currentWeapon = PlayerCrl.CurrentWeapon.transform.GetChild(PlayerCrl.CurrentWeaponNumber).GetComponent<CloseWeapon>();
        // ** �̵�
        if (Input.GetKey(KeyCode.A))
        {
            Anim.SetFloat("SpeedX", -1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Anim.SetFloat("SpeedX", 1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W) && Runing)
        {
            Anim.SetFloat("SpeedY", 1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S) && Runing)
        {
            Anim.SetFloat("SpeedY", -1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Anim.SetFloat("SpeedY", 0.5f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Anim.SetFloat("SpeedY", -0.5f, 0.1f, Time.deltaTime);
        }
        else
        {
            Anim.SetFloat("SpeedX", 0f, 0.1f, Time.deltaTime);
            Anim.SetFloat("SpeedY", 0f, 0.1f, Time.deltaTime);
        }

        // ** ����
        if (Input.GetKey(KeyCode.Space))
        {
            JumpCheck = true;
        }

        // ** ���ε�
        if (Input.GetKey(KeyCode.R) || currentWeapon.CurrentMagazine == 0)
        {
            Reroad = true;
        }
        else
            Reroad = false;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Runing = true;
        }
        else
            Runing = false;

        Anim.SetBool("Jump", JumpCheck);
        Anim.SetBool("ReRoad", Reroad);
    }

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.transform.tag == "Ground")
       {
           JumpCheck = false;
       }
    }
  
}
