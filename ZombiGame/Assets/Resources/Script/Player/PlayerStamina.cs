using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    // ** 스테미너 오브젝트 
    private GameObject StaminaPoint;
    private Slider AnchorPoint;
    // ** 스테미너 소모 속도
    private float Dmg;
    // ** 스테미너 회복 속도
    private float Recovery;

    // ** 최대 스테미너양
    private float MaxPlayerStamina = 100;
    // ** 현재 스테미너양
    private float HurrentPlayerStamina = 100;
    private void Awake()
    {
        // ** 오브젝트 스테미너 찾기
        StaminaPoint = GameObject.Find("Canvas/Stamina");
        // ** 찾은 오브젝트에 Slider를 받아온다.
        AnchorPoint = StaminaPoint.GetComponent<Slider>();
        // ** Slider의 최대값을 넣는다.
        AnchorPoint.maxValue = MaxPlayerStamina;
        // ** Slider의 최소값은 0으로 설정
        AnchorPoint.minValue = 0;
    }
    void Start()
    {
        // ** 데미지 설정
        Dmg = 20.0f;
        // ** 회복 설정
        Recovery = 15.0f;
        // ** Slider의 값은 100으로 설정
        AnchorPoint.value = AnchorPoint.maxValue;
    }

    void Update()
    {
        // ** Shift를 누를 때마다 스테미너 소모
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // ** Slider값이 최소값보다 클경우
            if (AnchorPoint.value >= AnchorPoint.minValue)
            {
                // ** Slider값 감소
                AnchorPoint.value -= (Dmg * Time.deltaTime);
            }
        }
        // ** Shift를 안누르면 서서히 회복
        else
        {
            if(AnchorPoint.value < AnchorPoint.maxValue)
            {
                // ** Slider값 증가
                AnchorPoint.value += (Recovery * Time.deltaTime);
            }
           
        }

        // ** Slider값을 현재스테미너에 저장
        HurrentPlayerStamina = AnchorPoint.value;
    }
}
