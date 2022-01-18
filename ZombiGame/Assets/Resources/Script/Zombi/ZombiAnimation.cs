using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiAnimation : MonoBehaviour
{
    private Animator Anim;
    private Zombiview view;

    private bool JumpCheck;
    private bool Runing;
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        view = GetComponent<Zombiview>();

    }

    private void Start()
    {

    }

    private void Update()
    {
        if (view.Attack == true)
        {
            Anim.SetBool("Walk", true);
            Anim.SetBool("Idle", false);
        }
        else
        {
            Anim.SetBool("Walk", false);
            Anim.SetBool("Idle", true);
        }
    }
}
