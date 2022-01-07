using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimetion : MonoBehaviour
{
    private Animator Anim;
    private bool JumpCheck;

    // ** 애니메이션 현재 상태
    private AnimatorStateInfo CurrentState;
    private AnimatorStateInfo PreviousState;
    private void Awake()
    {
        Anim = GetComponent<Animator>();
        CurrentState = Anim.GetCurrentAnimatorStateInfo(0);
        PreviousState = CurrentState;
    }
    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            CurrentState = Anim.GetCurrentAnimatorStateInfo(0);
            if (CurrentState.IsName("WAIT01"))
            {
                Anim.SetBool("Jump", true);
                PreviousState = CurrentState;
            }
        }

        if(Input.GetKey("up"))
        {
            CurrentState = Anim.GetCurrentAnimatorStateInfo(0);
            if (CurrentState.IsName("WAIT01"))
            {
                Anim.SetBool("Move", true);
                PreviousState = CurrentState;
            }
            if (CurrentState.IsName("RUN00_F") && Input.GetButtonDown("Jump"))
            {
                Anim.SetBool("Jump", true);
                PreviousState = CurrentState;
            }
        }
        else
        {
            Anim.SetBool("Move", false);
        }


        if(Anim.GetBool("Jump"))
        {
            CurrentState = Anim.GetCurrentAnimatorStateInfo(0);
            if(CurrentState.normalizedTime >= 0.5f)
            {
                if (PreviousState.nameHash != CurrentState.nameHash)
                {
                    Anim.SetBool("Jump", false);
                    PreviousState = CurrentState;
                }
            }            
        }
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Finish")
            Anim.SetBool("Win", true);
    }
}
