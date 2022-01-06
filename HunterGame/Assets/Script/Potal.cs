using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Potal : MonoBehaviour
{
    // 좀비만 소환하는 포탈 및 능력치 
    [SerializeField] private GameObject Zombi;
    

    private void Start()
    {
        Zombi = Resources.Load("Frefabs/Zombie") as GameObject;
       
        //인보크
        InvokeRepeating("CountSpawnDelay", 10.0f,10.0f);
    }


    public void CountSpawnDelay()
    {        
        if(GameManager.GetInstance.iNumber < GameManager.GetInstance.MaxZombiNumber)
        {
            // ** 몬스터 추가 예정
            GameObject Obj = Instantiate(Zombi);
            int num = Random.Range(1, 4);

            switch(num)
            {
                case 1:
                    Obj.transform.position = new Vector3(transform.position.x,-10.0f,-9.0f);
                    GameManager.GetInstance.EnemyList.Add(Obj);
                    break;
                case 2:
                    Obj.transform.position = new Vector3(transform.position.x, -16.0f,-9.0f);
                    GameManager.GetInstance.EnemyList.Add(Obj);
                    break;
                case 3:
                    Obj.transform.position = new Vector3(transform.position.x, -22.0f,-9.0f);
                    GameManager.GetInstance.EnemyList.Add(Obj);
                    break;
            }
            ++GameManager.GetInstance.iNumber;
        }
        else
        {
            CancelInvoke("CountSpawnDelay");
            
        }
    }

}
