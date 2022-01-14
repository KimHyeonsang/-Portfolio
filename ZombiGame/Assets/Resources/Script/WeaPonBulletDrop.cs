using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaPonBulletDrop : MonoBehaviour
{
    // ¶³¾îÁú ¹«±â °¹¼ö
    private int DropCount;

    // ·£´ý ¹«±â ¹øÈ£
    private int RandomWeaponNumber;

    [SerializeField] public GameObject WeaponPrefab1;
    [SerializeField] public GameObject WeaponPrefab2;
    [SerializeField] public GameObject WeaponPrefab3;
    [SerializeField] public GameObject WeaponPrefab4;

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
    }

    void Update()
    {
        for(int i=0;i<DropCount;++i)
        {
            RandomWeaponNumber = Random.Range(1, 10);

        }
    }
}
