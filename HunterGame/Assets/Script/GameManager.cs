using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class GameManager
{    
    static private GameManager Instance = null;

    // ** 플레이어 소환 리스트
    private List<GameObject> PlayerList = new List<GameObject>();

    // ** 적 소환 리스트
    public List<GameObject> EnemyList = new List<GameObject>();

    // ** 소환체 리스트
    public List<GameObject> SpawnList = new List<GameObject>();

    // ** 코인리스트
    public List<GameObject> CoinList = new List<GameObject>();


    public int MaxZombiNumber = 20;
    public int iNumber = 0;
    public int KillCount = 0;

    public int inGameMoney = 1000000;
    public int MaxPower = 150;
    public int CurPower = 150;
    public int Dia = 100000;

    public int AttackCount = 10;
    public int ProducerCount = 10;
    public int TankerCount = 10;
    // ** 최대스테이지
    public int MaxLevel = 4;
    // ** 현재 스테이지
    public int CurLevel;
    static public GameManager GetInstance
    {
        get
        {
            if (Instance == null)
            {
                Instance = new GameManager();
            }

            return Instance;
        }
    }

    public List<GameObject> GetPlayerList
    {
        get
        {
            return PlayerList;
        }
    }
}
