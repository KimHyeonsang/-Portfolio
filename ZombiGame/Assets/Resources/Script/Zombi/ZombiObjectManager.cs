using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiObjectManager 
{
    private static ZombiObjectManager Instance = null;

    public int MaxNomalZombi = 30;
    public int MaxSpeedZombi = 12;
    public int MaxTankerZombi = 8;
    public static ZombiObjectManager GetInstance
    {
        get
        {
            if(Instance == null)
            {
                Instance = new ZombiObjectManager();
            }
            return Instance;
        }
    }

    // ** 좀비를 관리 하는 리스트
    private List<GameObject> EnableList = new List<GameObject>();

    public List<GameObject> GetEnableList
    {
        get
        {
            return EnableList;
        }
    }

    // 쓰고 버리기 반복
    private Stack<GameObject> DisableList = new Stack<GameObject>();

    public Stack<GameObject>GetDisableList
    {
        get
        {
            return DisableList;
        }
    }
}
