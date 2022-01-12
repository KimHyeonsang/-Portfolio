using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimetion : MonoBehaviour
{
    private Animator Anim;

    private bool JumpCheck;
    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    void Start()
    {
        JumpCheck = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            Anim.SetFloat("SpeedX", -1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Anim.SetFloat("SpeedX", 1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.W))
        {
            Anim.SetFloat("SpeedY", 1f, 0.1f, Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            Anim.SetFloat("SpeedY", -1f, 0.1f, Time.deltaTime);
        }
        else
        {
            Anim.SetFloat("SpeedX", 0f, 0.1f, Time.deltaTime);
            Anim.SetFloat("SpeedY", 0f, 0.1f, Time.deltaTime);
        }

        // ** มกวม
        if (Input.GetKey(KeyCode.Space))
        {
            JumpCheck = true;
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            
        }
        Anim.SetBool("Jump", JumpCheck);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            JumpCheck = false;
    }
}
