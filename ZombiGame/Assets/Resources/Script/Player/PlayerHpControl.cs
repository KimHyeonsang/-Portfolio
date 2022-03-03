using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class PlayerHpControl : MonoBehaviour
{
    private GameObject HpPoint;
    private Slider AnchorPoint;

    private Text HpText;
    private GameObject HpObj;
    private float MaxPlayerHart = 100;
    public float HurrentPlayerHart = 100;
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
        AnchorPoint.value = AnchorPoint.maxValue;
    }

    void Update()
    {        
        HpText.text = HurrentPlayerHart.ToString() + " / " + MaxPlayerHart.ToString();
    }

    public void ZombiDmg(int _Dmg)
    {
        if(HurrentPlayerHart > 0)
        {
            AnchorPoint.value -= _Dmg;
            HurrentPlayerHart = AnchorPoint.value;
            GetComponent<PlayerAnimetion>().PlayerHit();
        }

        // 체력이 0이하일때
        if(HurrentPlayerHart <= 0)
        {
            GetComponent<PlayerAnimetion>().PlayerDie();
        }
    }
}
