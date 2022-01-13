using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerContorl : MonoBehaviour
{
    private float MoveSpeed;
    private float RunSpeed;
    private Rigidbody rid;

    private bool bJumping;

    private GameObject StaminaPoint;
    private Slider AnchorPoint;

    private void Awake()
    {
        rid = GetComponent<Rigidbody>();
        StaminaPoint = GameObject.Find("Canvas/Stamina");
        AnchorPoint = StaminaPoint.GetComponent<Slider>();
    }

    void Start()
    {
        MoveSpeed = 2.0f;
        RunSpeed = 4.0f;

        bJumping = false;
    }

    void Update()
    {
        PlayerMove();
        

        // 카메라가 보는방향을 캐릭터도 따라 방향을 본다
        transform.localRotation = Camera.main.transform.localRotation;
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

        // ** 스테미너의 Slider의 값이 0 초과일 경우
        if(AnchorPoint.value > 0)
        {
            // ** 달리기
            if (Input.GetKey(KeyCode.LeftShift))
            {
                // ** 달릴 때 스테미너 Ui출력
                StaminaPoint.SetActive(true);
                // ** 속도 변경
                MoveSpeed = RunSpeed;
            }
            // ** 달리지 않을 경우
            else
            {
                // 스테미너값이 99 초과일경우
                if(AnchorPoint.value > 99)
                    // ** 스테미너 UI 끄기
                    StaminaPoint.SetActive(false);
                // ** 기본 이동속도로 변경
                MoveSpeed = 2.0f;
            }
        }
        // ** 스테미너가 0이하일 경우
        else
        {
            // ** 탈진상태를 나타내기 위한 이동속도 감소
            MoveSpeed = 1.0f;
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
            bJumping = false;

        if (collision.transform.tag == "sniper")
            Debug.Log("Hit");
    }
}
