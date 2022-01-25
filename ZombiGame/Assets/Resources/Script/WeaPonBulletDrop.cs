using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaPonBulletDrop : MonoBehaviour
{
    // ¶³¾îÁú ¹«±â °¹¼ö
    private int DropCount;

    // ·£´ý ¹«±â ¹øÈ£
    private int RandomWeaponNumber;

    [SerializeField] public Vector2 Radius;

    [SerializeField] public GameObject WeaponPrefab1;
    [SerializeField] public GameObject WeaponPrefab2;
    [SerializeField] public GameObject WeaponPrefab3;
    [SerializeField] public GameObject WeaponPrefab4;

    private GameObject Obj;
    private void Awake()
    {
        WeaponPrefab1 = Resources.Load("Prefabs/Gun/assault") as GameObject;
        WeaponPrefab2 = Resources.Load("Prefabs/Gun/shotgun") as GameObject;
        WeaponPrefab3 = Resources.Load("Prefabs/Gun/smg") as GameObject;
        WeaponPrefab4 = Resources.Load("Prefabs/Gun/sniper") as GameObject;
    }
    void Start()
    {
        DropCount = 10;

        WayPointManager.GetInstance().PointA = new Vector2(transform.position.x - Radius.x, transform.position.z + Radius.y);
        WayPointManager.GetInstance().PointB = new Vector2(transform.position.x + Radius.x, transform.position.z - Radius.y);


        for (int i = 0; i < DropCount; ++i)
        {
            RandomWeaponNumber = Random.Range(1, 5);
            
            switch (RandomWeaponNumber)
            {
                case 1:
                    Obj = Instantiate(WeaponPrefab1);
                    Obj.GetComponent<Assault>().enabled = false;
                    break;
                case 2:
                    Obj = Instantiate(WeaponPrefab2);
               //     Obj.GetComponent<Assault>().enabled = false;
                    break;
                case 3:
                    Obj = Instantiate(WeaponPrefab3);
               //     Obj.GetComponent<Assault>().enabled = false;
                    break;
                case 4:
                     Obj = Instantiate(WeaponPrefab4);
               //     Obj.GetComponent<Assault>().enabled = false;
                    break;
            }
            Obj.AddComponent<Rigidbody>();
            Obj.transform.position = new Vector3(
            Random.Range(WayPointManager.GetInstance().PointA.x,
            WayPointManager.GetInstance().PointB.x),
            -10.0f,
            Random.Range(WayPointManager.GetInstance().PointA.y,
            WayPointManager.GetInstance().PointB.y));

            
        }
    }

}
