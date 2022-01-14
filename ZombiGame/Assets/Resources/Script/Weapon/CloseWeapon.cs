using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeapon : MonoBehaviour
{
    public string CloseWeaponName;

    // ** 총 유형
    public bool isAssault;
    public bool isShotgun;
    public bool isSmg;
    public bool isSniper;

    public int Damage; // 공격력
    public float MaxRange; // 최대 사거리
    public float AttackDelay; // 공격 딜레이 (몇초간격으로 쏠것인가)
    public float Reroad; // 장전 속도
}
