using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiSpawn : MonoBehaviour
{
    [SerializeField] private GameObject ZombiParent = null;
    [SerializeField] private GameObject NomalZombiPrefab = null;
    [SerializeField] private GameObject SpeedZombiPrefab = null;
    [SerializeField] private GameObject TankerZombiPrefab = null;

    [SerializeField] public Vector2 Radius;
    private void Awake()
    {
        ZombiParent = new GameObject("ZombiParents");
        NomalZombiPrefab = Resources.Load("Prefabs/zombi/zombiegirl") as GameObject;
    }
    void Start()
    {
        WayPointManager.GetInstance().PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        WayPointManager.GetInstance().PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);


        if (ZombiObjectManager.GetInstance.GetDisableList.Count == 0)
        {
            for(int i = 0;i < 60; ++i)
            {
                GameObject Obj = Instantiate(NomalZombiPrefab);
                Obj.transform.name = "NomalZombi";
                Obj.transform.position = new Vector3(
                Random.Range(WayPointManager.GetInstance().PointA.x,
                WayPointManager.GetInstance().PointB.x),
                -10.0f,
                Random.Range(WayPointManager.GetInstance().PointA.y,
                WayPointManager.GetInstance().PointB.y));
                ZombiObjectManager.GetInstance.GetDisableList.Push(Obj);

                Obj.transform.parent = ZombiParent.transform;
            }
        }

       
        for (int i = 0; i < ZombiObjectManager.GetInstance.GetDisableList.Count; ++i)
        {
            GameObject zombi = ZombiObjectManager.GetInstance.GetDisableList.Pop();
            ZombiObjectManager.GetInstance.GetEnableList.Add(zombi);
        }
    }

}
