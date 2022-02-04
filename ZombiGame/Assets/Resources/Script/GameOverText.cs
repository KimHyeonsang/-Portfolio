using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverText : MonoBehaviour
{
    private Text ZombiKillText;
    void Start()
    {
        ZombiKillText = GetComponent<Text>();
    }

    void Update()
    {
        ZombiKillText.text = "���� óġ �� : " + PlayerContorl.ZombiKill.ToString() + "���� \n\n\n " +
            "FŰ�� ��������.";


        if(Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainScene");
            WayPoint.WayPointList.Clear();
        }
    }
}
