using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLife : MonoBehaviour
{
    private int Life;

    private void Start()
    {
        Life = 1;
    }
    public void LifeDestroy()
    {
        if (Life >= 1)
            --Life;
        else
        {
            Destroy(gameObject);
            UIManager UiObj = GameObject.Find("UiManager").GetComponent<UIManager>();
            UiObj.LoseUIActive();
        }

        //gameover
    }
}
