using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    public GameObject VictoryUI;
    public GameObject SpawnUI;
    public GameObject OptionUI;
    public GameObject LoseUI;
    [Tooltip("메인 메뉴쪽 사용")]
    public GameObject MainUI;
    public GameObject StageSelectUI;
    public GameObject StageSelectExplanationBGUI;
    public GameObject PlayerPowerUI;
    public GameObject ShopUI;
    public GameObject DiaShopUI;
    public GameObject EggShopUI;


    public void VictoryUiActive()
    {
        if(VictoryUI.activeSelf == true)
        {
            VictoryUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            VictoryUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void SpawnUIActive()
    {
        if (SpawnUI.activeSelf == true)
        {
            SpawnUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            SpawnUI.SetActive(true);
            Time.timeScale = 0;
        }
    }
    public void OptionUIActive()
    {
        if (OptionUI.activeSelf == true)
        {
            OptionUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            OptionUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void LoseUIActive()
    {
        if (LoseUI.activeSelf == true)
        {
            LoseUI.SetActive(false);
            Time.timeScale = 1;
        }
        else
        {
            LoseUI.SetActive(true);
            Time.timeScale = 0;
        }
    }

    public void MainUIActive()
    {
        if (MainUI.activeSelf == true)
        {
            MainUI.SetActive(false);
        }
        else
        {
            MainUI.SetActive(true);
        }
    }
    public void StageSelectUIActive()
    {
        if (StageSelectUI.activeSelf == true)
        {
            StageSelectUI.SetActive(false);
        }
        else
        {
            StageSelectUI.SetActive(true);
        }
    }

    public void StageSelectExplanationBGUIActive()
    {
        if (StageSelectExplanationBGUI.activeSelf == true)
        {
            StageSelectExplanationBGUI.SetActive(false);
        }
        else
        {
            StageSelectExplanationBGUI.SetActive(true);
        }
    }

    public void PlayerPowerUIActive()
    {
        if (PlayerPowerUI.activeSelf == true)
        {
            PlayerPowerUI.SetActive(false);
        }
        else
        {
            PlayerPowerUI.SetActive(true);
        }
    }

    public void ShopUIActive()
    {
        if (ShopUI.activeSelf == true)
        {
            ShopUI.SetActive(false);
        }
        else
        {
            ShopUI.SetActive(true);
        }
    }
    public void DiaShopUIActive()
    {
        if (DiaShopUI.activeSelf == false)        
        {
            DiaShopUI.SetActive(true);
            EggShopUI.SetActive(false);
        }
    }
    public void EggShopUIActive()
    {
        if (EggShopUI.activeSelf == false)        
        {
            DiaShopUI.SetActive(false);
            EggShopUI.SetActive(true);
        }
    }
    public void ReStartScene()
    {
        // 초기화 목록  코인 기본가격,현재 좀비 소환 수 초기화,
        GameObject.Find("Cost").GetComponent<TextCost>().Cost = 100;

        for (int i = 0; i < GameManager.GetInstance.GetPlayerList.Count; ++i)
        {
            // 플레이어 지우기   
            Destroy(GameManager.GetInstance.GetPlayerList[i]);

        }
        for (int i = 0; i < GameManager.GetInstance.EnemyList.Count; ++i)
        {
            // 적군 지우기
            Destroy(GameManager.GetInstance.EnemyList[i]);
        }

        // 플레이어 소환 가능 장소 리셋
        for (int i = 0; i < GameManager.GetInstance.SpawnList.Count; ++i)
        {
            // 돌리기
            GameManager.GetInstance.SpawnList[i].SetActive(true);
        }

        // 필드에 나와있는 코인 삭제
        for (int i = 0; i < GameManager.GetInstance.CoinList.Count; ++i)
        {
            Destroy(GameManager.GetInstance.CoinList[i]);
        }
        GameManager.GetInstance.iNumber = 0;
        GameManager.GetInstance.EnemyList.Clear();
        GameManager.GetInstance.GetPlayerList.Clear();
        GameManager.GetInstance.CoinList.Clear();
        Time.timeScale = 1;
    }
}
