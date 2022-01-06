using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggOpen : MonoBehaviour
{
    private bool Open;
    private int DiaNumber;
    public GameObject TargetButton;

    public Image RandomImage;
    public Sprite AttackSprite;
    public Sprite TankerSprite;
    public Sprite ProducerSprite;
    public Sprite CoinSprite;

    public bool One;
    public bool Ten;
    void Start()
    {
        Open = false;
    }

    void Update()
    {
        if (Open)
        {

        }
    }

    public void RandomEggOpen()
    {        
        int RandomNum = Random.Range(0, 10);
        if(GameManager.GetInstance.Dia >= DiaNumber)
        {
            Open = true;
            switch(RandomNum)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    int RandomMoney = Random.Range(1000, 10000);
                    RandomImage.sprite = CoinSprite;
                    GameManager.GetInstance.inGameMoney += RandomMoney;
                    break;
                case 7:
                    RandomImage.sprite = ProducerSprite;
                    GameManager.GetInstance.ProducerCount++;
                    break;                               
                case 8:                                   
                    RandomImage.sprite = AttackSprite;
                    GameManager.GetInstance.AttackCount++;
                    break;
                case 9:
                    RandomImage.sprite = TankerSprite;
                    GameManager.GetInstance.TankerCount++;
                    break;
            }           
        }
    }

    public void RandomTenEggOpen()
    {
        GameObject[] Images = GameObject.FindGameObjectsWithTag("RandomImage");
        for (int i = 0;i < Images.Length; i++)
        {
            int RandomNum = Random.Range(0, 10);
            switch (RandomNum)
            {
                case 0:
                case 1:
                case 2:
                case 3:
                case 4:
                case 5:
                case 6:
                    int RandomMoney = Random.Range(1000, 10000);
                    Images[i].GetComponent<Image>().sprite = CoinSprite;
                    GameManager.GetInstance.inGameMoney += RandomMoney;
                    break;
                case 7:
                    Images[i].GetComponent<Image>().sprite = ProducerSprite;
                    GameManager.GetInstance.ProducerCount++;
                    break;
                case 8:
                    Images[i].GetComponent<Image>().sprite = AttackSprite;
                    GameManager.GetInstance.AttackCount++;
                    break;
                case 9:
                    Images[i].GetComponent<Image>().sprite = TankerSprite;
                    GameManager.GetInstance.TankerCount++;
                    break;
            }
        }        
    }
    public void OnClick(GameObject _Target)
    {
        // 어떤것을 선택을 하는것인가
        TargetButton = _Target;
        switch(TargetButton.name)
        {
            case "OneButton":
                DiaNumber = 200;

                if(GameManager.GetInstance.Dia >= DiaNumber)
                {
                    GameManager.GetInstance.Dia -= DiaNumber;
                    One = true;
                    Ten = false;
                }
                else
                {
                    One = false;
                    Ten = false;
                }
                break;
            case "TenButton":
                DiaNumber = 2000;
                if (GameManager.GetInstance.Dia >= DiaNumber)
                {
                    GameManager.GetInstance.Dia -= DiaNumber;
                    Ten = true;
                    One = false;
                }
                else
                {
                    One = false;
                    Ten = false;
                }
                break;
        }

    }
}
