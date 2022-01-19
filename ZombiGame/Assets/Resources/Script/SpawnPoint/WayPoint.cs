using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] public Vector2 Radius;

    [SerializeField] public GameObject WayPointPrefab;
    [SerializeField] public int WayPointCount = 0;
    [SerializeField] static public List<GameObject> WayPointList = new List<GameObject>();

    // 몬스터가 처음가야할 번호
    [SerializeField] private Vector3 Diretion;

    private float fTime = 2.0f;

    private void Awake()
    {
        WayPointPrefab = Resources.Load("Prefabs/WayPointPrefab") as GameObject;
    }

    private void Start()
    {
        StartCoroutine("CreateEnemy");

        WayPointManager.GetInstance().PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        WayPointManager.GetInstance().PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);

        for(int i = 0;i < WayPointCount;++i)
        {
            GameObject Obj = Instantiate(WayPointPrefab);

            Obj.AddComponent<Rigidbody>();
            Obj.AddComponent<BoxCollider>();

            Obj.transform.parent = transform;

            Obj.transform.position = new Vector3(
                Random.Range(WayPointManager.GetInstance().PointA.x,
                WayPointManager.GetInstance().PointB.x),
                5.0f,
                Random.Range(WayPointManager.GetInstance().PointA.y,
                WayPointManager.GetInstance().PointB.y));

            WayPointList.Add(Obj);
        }

        int NodeNumber = WayPointManager.GetInstance().NodeNumber;

    //    WayPointManager.GetInstance().TargetPoint = WayPointList[NodeNumber].transform.position;
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
        Enemy.transform.position = WayPointList[0].transform.position;
        Debug.Log(WayPointList[0].transform.position);

        Enemy.transform.parent = WayPointManager.GetInstance().ZombiParent.transform;
        ZombiObjectManager.GetInstance.GetDisableList.Push(Enemy);
    }
}
