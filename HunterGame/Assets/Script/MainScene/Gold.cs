using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Gold : MonoBehaviour
{
    private Text TGold;
    void Start()
    {
        TGold = GameObject.Find("GoldText").GetComponent<Text>();
    }

    void Update()
    {
        TGold.text = GameManager.GetInstance.inGameMoney.ToString();
    }
}
