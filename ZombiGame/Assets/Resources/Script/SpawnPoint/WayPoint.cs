using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] public Vector2 Radius;

    [SerializeField] public GameObject WayPointPrefab;
    [SerializeField] public int WayPointCount;
    [SerializeField] static public List<GameObject> WayPointList = new List<GameObject>();

    // 몬스터가 처음가야할 번호
    [SerializeField] private Vector3 Diretion;

    
    private float fTime = 5.0f;

    private void Awake()
    {
        WayPointPrefab = Resources.Load("Prefabs/WayPointPrefab") as GameObject;

        
    }

    private void Start()
    {
        WayPointManager.GetInstance().PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        WayPointManager.GetInstance().PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);

        for(int i = 0;i < WayPointCount;++i)
        {
            GameObject Obj = Instantiate(WayPointPrefab);
            Obj.transform.name = i.ToString();
            Obj.AddComponent<Rigidbody>();
            Obj.AddComponent<BoxCollider>();

            Obj.GetComponent<Rigidbody>().freezeRotation = true;
            Obj.transform.parent = transform;

            Obj.transform.position = new Vector3(
                Random.Range(WayPointManager.GetInstance().PointA.x,
                WayPointManager.GetInstance().PointB.x),
                1.0f,
                Random.Range(WayPointManager.GetInstance().PointA.y,
                WayPointManager.GetInstance().PointB.y));

            // 순서대로 다 저장
            WayPointList.Add(Obj);
        }
        // 몬스터 소환
        StartCoroutine("CreateEnemy");
        
        // 지금 번호를 불러온다
        int NodeNumber = WayPointManager.GetInstance().NodeNumber;

        // 지금 타겟된 위치는 WayPointList[NodeNumber]의 위치를 부른다.
        WayPointManager.GetInstance().TargetPoint = WayPointList[NodeNumber].transform.position;
        // 부른뒤 NodeNumber를 waypoint만큼 저장한다
        WayPointManager.GetInstance().NodeNumber = WayPointList.Count;
    }

    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(fTime);

        GameObject Enemy = Instantiate(WayPointManager.GetInstance().NomalZombiPrefab);
        Enemy.transform.name = "NomalZombi";
        Enemy.transform.Rotate(new Vector3(
              0,
              Random.Range(-180,
              180),
              0));
        Enemy.transform.position = this.transform.position;

        Enemy.transform.parent = WayPointManager.GetInstance().ZombiParent.transform;
        ZombiObjectManager.GetInstance.GetDisableList.Push(Enemy);
    }
}
