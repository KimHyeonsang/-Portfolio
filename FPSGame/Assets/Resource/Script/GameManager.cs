using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ����,���̵�,������Ʈ ����(���� ),�Ѿ� ����

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
