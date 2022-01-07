using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaterControl : MonoBehaviour
{
    private float Speed;
    private float JumpPower;
    private Rigidbody rb;

    private int JumpCount;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        Speed = 5.0f;
        JumpPower = 5.0f;
        JumpCount = 1;
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

        
        if (Input.GetButtonDown("Jump"))
        {
            if(JumpCount == 1)
            {
                JumpCount = 0;
                rb.AddForce(Vector3.up * JumpPower, ForceMode.VelocityChange);
            }                      
        }
      

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            JumpCount = 1;
    }
}

