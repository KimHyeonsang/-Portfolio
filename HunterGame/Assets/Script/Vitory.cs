using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Vitory : MonoBehaviour
{    
    void Start()
    {
        // 소환 목록
        UIManager UiObj = GameObject.Find("UiManager").GetComponent<UIManager>();
       
        StageManager.Next_Level();
        // 초기화
        UiObj.ReStartScene();
        GameManager.GetInstance.inGameMoney += 50;

    }

}
