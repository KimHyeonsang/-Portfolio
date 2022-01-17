using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStamina : MonoBehaviour
{
    // ** ���׹̳� ������Ʈ 
    private GameObject StaminaPoint;
    private Slider AnchorPoint;
    // ** ���׹̳� �Ҹ� �ӵ�
    private float Dmg;
    // ** ���׹̳� ȸ�� �ӵ�
    private float Recovery;

    // ** �ִ� ���׹̳ʾ�
    private float MaxPlayerStamina = 100;
    // ** ���� ���׹̳ʾ�
    private float HurrentPlayerStamina = 100;
    private void Awake()
    {
        // ** ������Ʈ ���׹̳� ã��
        StaminaPoint = GameObject.Find("Canvas/Stamina");
        // ** ã�� ������Ʈ�� Slider�� �޾ƿ´�.
        AnchorPoint = StaminaPoint.GetComponent<Slider>();
        // ** Slider�� �ִ밪�� �ִ´�.
        AnchorPoint.maxValue = MaxPlayerStamina;
        // ** Slider�� �ּҰ��� 0���� ����
        AnchorPoint.minValue = 0;
    }
    void Start()
    {
        // ** ������ ����
        Dmg = 20.0f;
        // ** ȸ�� ����
        Recovery = 15.0f;
        // ** Slider�� ���� 100���� ����
        AnchorPoint.value = AnchorPoint.maxValue;
    }

    void Update()
    {
        // ** Shift�� ���� ������ ���׹̳� �Ҹ�
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // ** Slider���� �ּҰ����� Ŭ���
            if (AnchorPoint.value >= AnchorPoint.minValue)
            {
                // ** Slider�� ����
                AnchorPoint.value -= (Dmg * Time.deltaTime);
            }
        }
        // ** Shift�� �ȴ����� ������ ȸ��
        else
        {
            if(AnchorPoint.value < AnchorPoint.maxValue)
            {
                // ** Slider�� ����
                AnchorPoint.value += (Recovery * Time.deltaTime);
            }
           
        }

        // ** Slider���� ���罺�׹̳ʿ� ����
        HurrentPlayerStamina = AnchorPoint.value;
    }
}
