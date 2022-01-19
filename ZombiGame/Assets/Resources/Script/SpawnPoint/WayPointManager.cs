using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPointManager : MonoBehaviour
{
    private static WayPointManager Instance = null;
    private static GameObject Container = null;

    public static WayPointManager GetInstance()
    {
        if(Instance == null)
        {
            Container = new GameObject("WayPointManager");
            Instance = new WayPointManager();

            Instance = Container.AddComponent(typeof(WayPointManager)) as WayPointManager;
        }

        return Instance;
    }

    // ** 좀비 프리팹들
    [SerializeField] public GameObject ZombiParent = null;
    [SerializeField] public GameObject WayPointParent = null;
    [SerializeField] public GameObject NomalZombiPrefab = null;
//    [SerializeField] public GameObject SpeedZombiPrefab = null;
//    [SerializeField] public GameObject TankerZombiPrefab = null;

    [Tooltip("Node Prefab")]
    [HideInInspector] public GameObject WayPointList;

    [HideInInspector] public Vector2 PointA;
    [HideInInspector] public Vector2 PointB;

    [HideInInspector] public int NodeNumber;

    [HideInInspector] public Vector3 TargetPoint;



    [HideInInspector] public List<GameObject> NodeList;


    private void Awake()
    {
        ZombiParent = new GameObject("ZombiParents");
        WayPointParent = new GameObject("WayPointParents");
        NomalZombiPrefab = Resources.Load("Prefabs/zombi/zombiegirl") as GameObject;
        WayPointList = Resources.Load("Prefabs/WayPointList") as GameObject;
        NodeList = new List<GameObject>();
    }
    private void Start()
    {
        NodeNumber = 0;

        TargetPoint = new Vector3(0.0f, -0.0f, 0.0f);

        for (int i = 0; i < 60; ++i)
        {
            GameObject Obj = Instantiate(WayPointList);
            Obj.transform.parent = WayPointParent.transform;
            Obj.transform.position = new Vector3(Random.Range(-21, 70),
                0.0f,
                Random.Range(-40, 20));

        }
        // 저장된 좀비 수만큼 저장
        for (int i = 0; i < ZombiObjectManager.GetInstance.GetDisableList.Count; ++i)
        {
            GameObject zombi = ZombiObjectManager.GetInstance.GetDisableList.Pop();
            ZombiObjectManager.GetInstance.GetEnableList.Add(zombi);
        }
    }
}
