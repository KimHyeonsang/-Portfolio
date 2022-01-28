using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] public Vector2 Radius;

    [SerializeField] public GameObject WayPointPrefab;
    [SerializeField] public int WayPointCount;
    [SerializeField] static public List<GameObject> WayPointList = new List<GameObject>();
    [SerializeField] static public int NomalZombiCount = 0;
    [SerializeField] static public int SpeedZombiCount = 0;
    [SerializeField] static public int TankerZombiCount = 0;

    // 몬스터가 처음가야할 번호
    [SerializeField] private Vector3 Diretion;
    public GameObject Enemy;
    IEnumerator myCoroutine;
    private float fMonsterTime = 5.0f;
    private float fTime = 3.0f;

    private void Awake()
    {
        WayPointPrefab = Resources.Load("Prefabs/WayPointPrefab") as GameObject;

        
    }

    private void Start()
    {
        WayPointManager.GetInstance().WayPointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        WayPointManager.GetInstance().WayPointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);

        for(int i = 0;i < WayPointCount;++i)
        {
            GameObject Obj = Instantiate(WayPointPrefab);
            Obj.transform.name = i.ToString();
            Obj.AddComponent<Rigidbody>();
            Obj.AddComponent<BoxCollider>();

            
           
            Obj.GetComponent<Rigidbody>().freezeRotation = true;
            Obj.transform.parent = transform;

            Obj.transform.position = new Vector3(
                Random.Range(WayPointManager.GetInstance().WayPointA.x,
                WayPointManager.GetInstance().WayPointB.x),
                -5.0f,
                Random.Range(WayPointManager.GetInstance().WayPointA.y,
                WayPointManager.GetInstance().WayPointB.y));

            myCoroutine = SaveWayPoint(Obj);
            StartCoroutine(myCoroutine);
            
        }
        // 몬스터 소환
        StartCoroutine("CreateEnemy");
    }

    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(fMonsterTime);

        if (ZombiObjectManager.GetInstance.GetDisableList.Count == 0)
        {
            if (NomalZombiCount < ZombiObjectManager.GetInstance.MaxNomalZombi)
            {
                ++NomalZombiCount;
                Enemy = Instantiate(WayPointManager.GetInstance().NomalZombiPrefab);
                Enemy.transform.name = "NomalZombi";
            }
            else if (SpeedZombiCount < ZombiObjectManager.GetInstance.MaxSpeedZombi)
            {
                ++SpeedZombiCount;
                Enemy = Instantiate(WayPointManager.GetInstance().SpeedZombiPrefab);
                Enemy.transform.name = "SpeedZombi";
            }
            else if (TankerZombiCount < ZombiObjectManager.GetInstance.MaxTankerZombi)
            {
                ++TankerZombiCount;
                Enemy = Instantiate(WayPointManager.GetInstance().TankerZombiPrefab);
                Enemy.transform.name = "TankerZombi";
            }

            // 랜덤 방향
            Enemy.transform.Rotate(new Vector3(
                  0,
                  Random.Range(-180,
                  180),
                  0));

            // 위치
            Enemy.transform.position = this.transform.GetChild(0).transform.position;

            // 부모GameObject에게 넣기
            Enemy.transform.parent = WayPointManager.GetInstance().ZombiParent.transform;

            // 저장
            ZombiObjectManager.GetInstance.GetDisableList.Push(Enemy);
        }

        //저장한것을 부르고 삭제
        GameObject zombi = ZombiObjectManager.GetInstance.GetDisableList.Pop();
        // 위치 저장
        zombi.transform.position = Enemy.transform.position;
        // 리스트로 저장
        ZombiObjectManager.GetInstance.GetEnableList.Add(zombi);
    }

    IEnumerator SaveWayPoint(GameObject _Obj)
    {
        yield return new WaitForSeconds(fTime);

        // 순서대로 다 저장
        WayPointList.Add(_Obj);
    }
}
