using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public GameObject[] LevelUnLock;
    public static int Level = 1;
    private int num = 0;
    private void Start()
    {
        if(num == 0)
        {
            DeletePrefs();
            num = 1;
        }
        Level = PlayerPrefs.GetInt("Level", Level);        
    }

    private void Update()
    {
        for (int i = 0; i < GameManager.GetInstance.MaxLevel; ++i)
        {
            if (i < Level)
            {
                LevelUnLock[i].SetActive(false);
            }
            else
            {
                LevelUnLock[i].SetActive(true);
            }
        }
    }

    public static void Next_Level()
    {       
        Level += 1;
        PlayerPrefs.SetInt("Level", Level);        
    }

    public void Reset()
    {
        Level = 1;
        PlayerPrefs.SetInt("Level", Level);
    }

    public void DeletePrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}
