using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] public Vector2 Radius;

    [SerializeField] public GameObject WayPointPrefab;
    [SerializeField] public int WayPointCount;
    [SerializeField] static public List<GameObject> WayPointList = new List<GameObject>();

    // ���Ͱ� ó�������� ��ȣ
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

            // ������� �� ����
            WayPointList.Add(Obj);
        }
        // ���� ��ȯ
        StartCoroutine("CreateEnemy");
        
        // ���� ��ȣ�� �ҷ��´�
        int NodeNumber = WayPointManager.GetInstance().NodeNumber;

        // ���� Ÿ�ٵ� ��ġ�� WayPointList[NodeNumber]�� ��ġ�� �θ���.
        WayPointManager.GetInstance().TargetPoint = WayPointList[NodeNumber].transform.position;
        // �θ��� NodeNumber�� waypoint��ŭ �����Ѵ�
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
