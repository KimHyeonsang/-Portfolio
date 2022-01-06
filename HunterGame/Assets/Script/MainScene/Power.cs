using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Power : MonoBehaviour
{
    private Text TPower;
    void Start()
    {
        TPower = GameObject.Find("PowerText").GetComponent<Text>();
        TPower.text = GameManager.GetInstance.CurPower.ToString() + "/" + GameManager.GetInstance.MaxPower.ToString();
    }

    void Update()
    {
        TPower.text = GameManager.GetInstance.CurPower.ToString() + "/" + GameManager.GetInstance.MaxPower.ToString();
    }
}
