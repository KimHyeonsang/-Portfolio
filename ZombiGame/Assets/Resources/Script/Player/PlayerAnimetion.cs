using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimetion : MonoBehaviour
{
    private Animator Anim;

    private bool JumpCheck;
    private bool Runing;
    private bool Reroad;
    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    void Start()
    {
        JumpCheck = false;
        Runing = false;
        Reroad = false;
    }

    void Update()
    {
        // ** 이동
        if (Input.GetKey(KeyCode.A))
        {
            Anim.SetFloat("SpeedX", -1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Anim.SetFloat("SpeedX", 1f, 0.1f, Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.W) && Runing)
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

        // ** 점프
        if (Input.GetKey(KeyCode.Space))
        {
            JumpCheck = true;
        }

        // ** 리로드
        if (Input.GetKey(KeyCode.R))
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
