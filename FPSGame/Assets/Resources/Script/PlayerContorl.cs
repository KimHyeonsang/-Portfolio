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
    private GameObject ButtonImage;

    private GameObject PlayerSwan;
    private GameObject EmptyObj;
    private GameObject CurrentWeapon;
    private void Awake()
    {
        rid = GetComponent<Rigidbody>();
        StaminaPoint = GameObject.Find("Canvas/Stamina");
        AnchorPoint = StaminaPoint.GetComponent<Slider>();

        ButtonImage = GameObject.Find("Canvas/GButtonImage");

        PlayerSwan = Resources.Load("Prefabs/Player2") as GameObject;
        EmptyObj = Instantiate(PlayerSwan);
    }

    void Start()
    {
        MoveSpeed = 2.0f;
        RunSpeed = 4.0f;

        bJumping = false;
        ButtonImage.SetActive(false);
    }

    void Update()
    {
        PlayerMove();
        

        // ī�޶� ���¹����� ĳ���͵� ���� ������ ����
        transform.localRotation = Camera.main.transform.localRotation;
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

        // ** ���׹̳��� Slider�� ���� 0 �ʰ��� ���
        if(AnchorPoint.value > 0)
        {
            // ** �޸���
            if (Input.GetKey(KeyCode.LeftShift))
            {
                // ** �޸� �� ���׹̳� Ui���
                StaminaPoint.SetActive(true);
                // ** �ӵ� ����
                MoveSpeed = RunSpeed;
            }
            // ** �޸��� ���� ���
            else
            {
                // ���׹̳ʰ��� 99 �ʰ��ϰ��
                if(AnchorPoint.value > 99)
                    // ** ���׹̳� UI ���
                    StaminaPoint.SetActive(false);
                // ** �⺻ �̵��ӵ��� ����
                MoveSpeed = 2.0f;
            }
        }
        // ** ���׹̳ʰ� 0������ ���
        else
        {
            // ** Ż�����¸� ��Ÿ���� ���� �̵��ӵ� ����
            MoveSpeed = 1.0f;
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            bJumping = false;

        }
        else if(collision.transform.tag == "sniper")
        {
            ButtonImage.SetActive(true);
            //    if (Input.GetKey(KeyCode.G))
            //    {
            GameObject.Find("Player2(Clone)").transform.Find("assault").gameObject.SetActive(false);
        //    CurrentWeapon = GameObject.FindGameObjectWithTag("assault");
        //    CurrentWeapon.SetActive(false);
            GameObject.Find("Player2(Clone)").transform.Find("sniper").gameObject.SetActive(true);
            

            //    CurrentWeapon = GameObject.Find("sniper");

        //   for(int i=0;i< EmptyObj.transform.childCount;i++)
        //   {
        //       Debug.Log(EmptyObj.transform.childCount);
        //   }
            //    }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "sniper")
        {
            ButtonImage.SetActive(false);
        }
    }
}
