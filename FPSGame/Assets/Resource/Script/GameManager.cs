using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // 사운드,난이도,오브젝트 관리(좀비 ),총알 관리

    private static GameManager instance = null;


    
    public GameManager GetInstance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();               
            }

            return instance;
        }
       
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
