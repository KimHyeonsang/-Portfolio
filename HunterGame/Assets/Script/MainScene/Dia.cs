using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Dia : MonoBehaviour
{
    private Text TCost;
    void Start()
    {
        TCost = GameObject.Find("DiaText").GetComponent<Text>();
        TCost.text = GameManager.GetInstance.Dia.ToString();
    }

    void Update()
    {
        TCost.text = GameManager.GetInstance.Dia.ToString();
    }
}
