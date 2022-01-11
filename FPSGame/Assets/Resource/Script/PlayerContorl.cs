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
        

        // ī�޶� ���¹����� ĳ���͵� ���� ������ ����
        transform.localRotation = cam.transform.localRotation;
        // y������ ȸ���ϴ°͸� ĳ���Ͱ� ȸ���� �Ѵ�.
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);

    }
    
    // ** �÷��̾� �̵� ����
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

        // ** ����
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
