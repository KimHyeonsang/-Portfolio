using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StarText : MonoBehaviour
{
    private Text Star1;
    void Start()
    {
        Star1 = GameObject.Find("01Text").GetComponent<Text>();
        Star1.text = "좀비를 모두 잡아서 새들의 집을 지켜보아요";

    }

}
