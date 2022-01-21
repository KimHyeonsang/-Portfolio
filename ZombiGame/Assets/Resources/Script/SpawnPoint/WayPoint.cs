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
        // ���� ��ȯ
        StartCoroutine("CreateEnemy");
    }

    IEnumerator CreateEnemy()
    {
        yield return new WaitForSeconds(fMonsterTime);

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

    IEnumerator SaveWayPoint(GameObject _Obj)
    {
        yield return new WaitForSeconds(fTime);

        // ������� �� ����
        WayPointList.Add(_Obj);
    }
}
