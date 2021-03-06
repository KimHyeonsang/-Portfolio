using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 사운드,난이도,오브젝트 관리(좀비 ),총알 관리

    private static GameManager instance = null;
    public int Stage = 1;
    private GameObject PlayerSwan;
    private GameObject EmptyObj;
    public bool completecheck = false;

    public static GameManager GetInstance()
    {
        if (instance == null)
        {
            instance = new GameManager();
        }

        return instance;
    }

    private void Start()
    {
        WayPointManager.GetInstance();
        WayPoint.NomalZombiCount = 0;
        WayPoint.SpeedZombiCount = 0;
        WayPoint.TankerZombiCount = 0;
        completecheck = false;
    }
    public GameObject Spawn()
    {
       PlayerSwan = Resources.Load("Prefabs/Players/Player") as GameObject;
       EmptyObj = Instantiate(PlayerSwan);
       switch (Stage)
       {
           case 1:
               EmptyObj.transform.position = GameObject.Find("Stage1").transform.position;
               break;
           case 2:
               break;
           case 3:
               break;
       }
       return EmptyObj;
    }
}
