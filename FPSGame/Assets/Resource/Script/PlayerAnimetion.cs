using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimetion : MonoBehaviour
{
    private Animator Anim;

    private void Awake()
    {
        Anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    void Update()
    {
        var Hor = Input.GetAxisRaw("Horizontal");
        var Ver = Input.GetAxisRaw("Vertical");


        if(Ver > 0.5)
            Anim.SetFloat("Walk", 0.6f);
        else
            Anim.SetFloat("Walk", 0.0f);
    }
}
