using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterControl : MonoBehaviour
{
    private float Speed;

    private Animator Anime;

    private bool JumpCheck;
    private void Awake()
    {
        Anime = GetComponent<Animator>();
    }
    void Start()
    {
        Speed = 5.0f;
        JumpCheck = false;
    }

    void Update()
    {
        if(Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * Speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(Vector3.back * Speed * Time.deltaTime);
        }

        if(!JumpCheck)
        {
            if (Input.GetButtonDown("Jump"))
            {
                transform.Translate(Vector3.up * 30 * Time.deltaTime);
                JumpCheck = true;
                Anime.SetBool("Jump", JumpCheck);
            }
        }
        else
            JumpCheck = false;

        //    Anime.SetBool("Jump", JumpCheck);
    }

    private void LateUpdate()
    {
     //   JumpCheck = false;

        Anime.SetBool("Jump", JumpCheck);
    }
}

