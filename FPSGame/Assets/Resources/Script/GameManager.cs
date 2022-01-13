using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // ����,���̵�,������Ʈ ����(���� ),�Ѿ� ����

    private static GameManager instance = null;
    public int Stage = 1;
    private GameObject PlayerSwan;
    private GameObject EmptyObj;
   
    public static GameManager GetInstance
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
    
    public GameObject Spawn()
    {
        PlayerSwan = Resources.Load("Prefabs/Player2") as GameObject;
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
