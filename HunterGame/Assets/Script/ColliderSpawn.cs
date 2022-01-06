using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSpawn : MonoBehaviour
{
    void Start()
    {
        GameObject[] Obj = GameObject.FindGameObjectsWithTag("PlayerSpawn");
        for(int i = 0;i < Obj.Length; ++i)
        {
            GameManager.GetInstance.SpawnList.Add(Obj[i]);
        }
    }

}
