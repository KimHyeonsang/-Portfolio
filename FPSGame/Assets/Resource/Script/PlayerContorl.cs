using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorl : MonoBehaviour
{
    private float MoveSpeed;
    private float RunSpeed;
    private Rigidbody rid;

    private bool bJumping;
    public Camera cam;
    private void Awake()
    {
        rid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        MoveSpeed = 5.0f;
        RunSpeed = 9.0f;

        bJumping = false;
    }

    void Update()
    {
        PlayerMove();
        

        // 카메라가 보는방향을 캐릭터도 따라 방향을 본다
        transform.localRotation = cam.transform.localRotation;
        // y축으로 회전하는것만 캐릭터가 회전을 한다.
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);

    }
    
    // ** 플레이어 이동 관련
    private void PlayerMove()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, MoveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -MoveSpeed * Time.deltaTime);
        }

        // ** 점프
        if (Input.GetKey(KeyCode.Space))
        {
            if (bJumping == false)
            {
                bJumping = true;
                rid.AddForce(Vector3.up * 200);
            }
        }

        if(Input.GetKey(KeyCode.LeftShift))
        {
            MoveSpeed = RunSpeed;
        }
        else
        {
            MoveSpeed = 5.0f;
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            bJumping = false;
    }
}
