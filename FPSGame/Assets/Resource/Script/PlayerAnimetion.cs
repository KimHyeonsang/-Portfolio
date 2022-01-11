using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimetion : MonoBehaviour
{
    private Animator Anim;

    private float Move;
    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    void Start()
    {
        Move = 0.0f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {

        }
        else if (Input.GetKey(KeyCode.D))
        {

        }

        if (Input.GetKey(KeyCode.W))
        {
            if(Move < 0.6f)
                Move += 0.1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            if (Move >= 0.0f)
                Move -= 0.1f;
        }

        // ** มกวม
        if (Input.GetKey(KeyCode.Space))
        {
            
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            
        }
        Anim.SetFloat("Walk", Move);
    }
}
