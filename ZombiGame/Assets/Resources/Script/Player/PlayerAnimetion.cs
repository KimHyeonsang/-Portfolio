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
            StartCoroutine(GunReroad());
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            Runing = true;
        }
        else
            Runing = false;

        if (Input.GetMouseButtonDown(0)&& Reroad == false)
        {
            if(currentWeapon.CurrentMagazine > 0)
                PlayerShoot();
        }

        Anim.SetBool("Jump", JumpCheck);
        Anim.SetBool("ReRoad", Reroad);
    }

    public void PlayerDie()
    {
        Anim.SetBool("Dying", true);
    }

    public void PlayerHit()
    {
        Anim.SetTrigger("Dmg");
    }

    public void PlayerShoot()
    {
        Anim.SetTrigger("Shoot");
    }

    private IEnumerator GunReroad()
    {
        Reroad = true;

        yield return new WaitForSeconds(3.0f);

        Reroad = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
       if (collision.transform.tag == "Ground")
       {
           JumpCheck = false;
       }
    }
  
}
