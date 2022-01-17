using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiControl : MonoBehaviour
{
    private Animator Anim;
    private Zombiview view;

    [SerializeField] private GameObject Target;
    private bool JumpCheck;
    private bool Runing;
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        view = GetComponent<Zombiview>();
        
    }

    private void Start()
    {
        Target = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        if (view.Attack == true)
        {
            Anim.SetBool("Walk", true);
            Anim.SetBool("Idle", false);
            transform.LookAt(Target.transform);
        }
        else
        {
            Anim.SetBool("Walk", false);
            Anim.SetBool("Idle", true);
        }
    }

}
