using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHpControl : MonoBehaviour
{
    private float HpSpeed;
    private GameObject HpPoint;
    private Slider AnchorPoint;
    private float Dmg;

    private Text HpText;
    private GameObject HpObj;
    private float MaxPlayerHart = 100;
    private float HurrentPlayerHart = 100;
    private void Awake()
    {
        HpPoint = GameObject.Find("Canvas/PlayerHp");
        AnchorPoint = HpPoint.GetComponent<Slider>();
        AnchorPoint.maxValue = MaxPlayerHart;
        AnchorPoint.minValue = 0;
        HpObj = GameObject.Find("Canvas/PlayerHp/HPText");
        HpText = HpObj.GetComponent<Text>();
    }
    void Start()
    {
        HpSpeed = 5.0f;
        Dmg = 0.5f;
        AnchorPoint.value = AnchorPoint.maxValue;
    }

    void Update()
    {
        float MouseWheel = Input.GetAxis("Mouse ScrollWheel");

        if (MouseWheel > 0)
        {
            AnchorPoint.value += Dmg;
            HurrentPlayerHart = AnchorPoint.value;
        }

        if (MouseWheel < 0)
        {
            AnchorPoint.value -= Dmg;
            HurrentPlayerHart = AnchorPoint.value;
        }

        HpText.text = HurrentPlayerHart.ToString() + " / " + MaxPlayerHart.ToString();
    }
}
