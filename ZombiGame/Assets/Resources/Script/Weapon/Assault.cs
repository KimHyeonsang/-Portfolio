using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Assault : MonoBehaviour
{
    private CloseWeapon Weapon;
    void Start()
    {
        Weapon = GetComponent<CloseWeapon>();
    }

    void Update()
    {
        
    }
}
