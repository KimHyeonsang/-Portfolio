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
        ZombiKillText.text = "좀비 처치 수 : " + PlayerContorl.ZombiKill.ToString() + "마리 \n\n\n " +
            "F키를 누르세요.";


        if(Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = 1;
            SceneManager.LoadScene("MainScene");
            WayPoint.WayPointList.Clear();
        }
    }
}
