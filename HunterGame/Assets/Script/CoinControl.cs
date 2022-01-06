using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinControl : MonoBehaviour
{
    private bool bStartMove;
    // ** 코인의 가격
    private int Coin;
    [SerializeField] private GameObject Obj;

    private GameObject victoryui;
    void Start()
    {
        bStartMove = false;
        Obj = GameObject.Find("SpwonCoin");
        Coin = 50;
        UIManager UiObj = GameObject.Find("UiManager").GetComponent<UIManager>();
        victoryui = UiObj.VictoryUI;
    }

    void Update()
    {
        if (victoryui.activeSelf == true)
        {
            Destroy(gameObject);
        }

        Vector2 Pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        RaycastHit2D Hit = Physics2D.Raycast(Pos, Vector2.zero, -9.0f);

        if(Input.GetMouseButtonDown(0))
        {
            if (Hit.collider != null)
            {
                if (Hit.transform.tag == "Coin")
                {
                    bStartMove = true;                    
                }
            }
        }

        if(bStartMove)
        {
            Vector3 Pos1 = Camera.main.ScreenToWorldPoint(Obj.transform.position);

            transform.position = Vector3.MoveTowards(transform.position, Pos1, 30.0f * Time.deltaTime);

            if(transform.position == Pos1)
            {
                bStartMove = false;

                TextCost CoinText = GameObject.Find("Cost").GetComponent<TextCost>();
                CoinText.Cost += Coin;
                Destroy(gameObject);
            }
        }
                
    }
}
