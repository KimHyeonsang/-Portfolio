using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextCost : MonoBehaviour
{
    private Text TCost;
    public int Cost = 100;
    private void Start()
    {
        TCost = GameObject.Find("Cost").GetComponent<Text>();
        TCost.text = Cost.ToString();
    }

    private void Update()
    {
        TCost.text = Cost.ToString();
    }
}
