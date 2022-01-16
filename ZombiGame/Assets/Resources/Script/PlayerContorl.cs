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

    // ** 현재무기
    private GameObject CurrentWeapon;
    private int CurrentWeaponNumber;
    private int AffterWeaponNumber;

    private Image Weapon2DImage;

    private void Awake()
    {
        rid = GetComponent<Rigidbody>();
        StaminaPoint = GameObject.Find("Canvas/Stamina");
        AnchorPoint = StaminaPoint.GetComponent<Slider>();

        ButtonImage = GameObject.Find("Canvas/GButtonImage");
        CurrentWeaponNumber = 0;

        GameObject WeaponImge = GameObject.Find("Canvas/BackGroundImage/Image");
        Weapon2DImage = WeaponImge.GetComponent<Image>();
        Weapon2DImage.sprite = Resources.Load("Image/Automatic rifle") as Sprite;
    }

    void Start()
    {
        MoveSpeed = 2.0f;
        RunSpeed = 4.0f;

        bJumping = false;
        ButtonImage.SetActive(false);

        // ** 현재 무기의 번호알기
        CurrentWeapon = GameObject.FindGameObjectWithTag("WeaponPoint");
    }

    void Update()
    {
        PlayerMove();
        

        // 카메라가 회전을 할때 플레이어도 회전
        transform.localRotation = Camera.main.transform.localRotation;
        // y값 위치만 조정
        transform.localRotation = new Quaternion(0, transform.localRotation.y, 0, transform.localRotation.w);

    }
    
    // ** 플레이어 이동관련
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

        // ** 스테미너 값이 0 초과일경우
        if(AnchorPoint.value > 0)
        {
            // ** 달리면
            if (Input.GetKey(KeyCode.LeftShift))
            {
                // ** 스테미너 창 오픈
                StaminaPoint.SetActive(true);
                // ** 이동속도가 뛰는속도로 바뀜
                MoveSpeed = RunSpeed;
            }
            // ** 안달리면
            else
            {
                // 스테미너값이 99초과일 경우
                if(AnchorPoint.value > 99)
                    // ** 스테미너 Ui꺼짐
                    StaminaPoint.SetActive(false);
                // ** 속도는 걷는속도로 돌아옴
                MoveSpeed = 2.0f;
            }
        }
        // ** 스테미너값이 0이하일 경우
        else
        {
            // ** 이동속도 1.0으로 감소
            MoveSpeed = 1.0f;
        }
    }
   
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Ground")
        {
            bJumping = false;

        }
        else if(collision.transform.tag == "assault" || collision.transform.tag == "smg"
            || collision.transform.tag == "shotgun" || collision.transform.tag == "sniper")
        {
            ButtonImage.SetActive(true);
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.transform.tag == "assault" || collision.transform.tag == "smg"
            || collision.transform.tag == "shotgun" || collision.transform.tag == "sniper")
        {
            if(Input.GetKey(KeyCode.G))
            {
                switch (collision.transform.tag)
                {
                    case "assault":
                        AffterWeaponNumber = 0;
                        Weapon2DImage.sprite = Resources.Load("Image/Automatic rifle") as Sprite;
                        break;
                    case "shotgun":
                        AffterWeaponNumber = 1;
                        Weapon2DImage.sprite = Resources.Load("Image/Automatic shotgun") as Sprite;
                        break;
                    case "smg":
                        AffterWeaponNumber = 2;
                        Weapon2DImage.sprite = Resources.Load("Image/Submachinegun") as Sprite;
                        break;
                    case "sniper":
                        AffterWeaponNumber = 3;
                        Weapon2DImage.sprite = Resources.Load("Image/Sniper") as Sprite;
                        break;
                }
                CurrentWeapon.transform.GetChild(CurrentWeaponNumber).gameObject.SetActive(false);
                CurrentWeapon.transform.GetChild(AffterWeaponNumber).gameObject.SetActive(true);
                CurrentWeaponNumber = AffterWeaponNumber;
                Destroy(collision.gameObject);
                ButtonImage.SetActive(false);
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.transform.tag == "assault" || collision.transform.tag == "smg"
            || collision.transform.tag == "shotgun" || collision.transform.tag == "sniper")
        {
            ButtonImage.SetActive(false);
        }
    }
}
