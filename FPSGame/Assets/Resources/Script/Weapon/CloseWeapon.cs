using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeapon : MonoBehaviour
{
    public string CloseWeaponName;

    // ** �� ����
    public bool isAssault;
    public bool isShotgun;
    public bool isSmg;
    public bool isSniper;

    public int Damage; // ���ݷ�
    public float MaxRange; // �ִ� ��Ÿ�
    public float AttackDelay; // ���� ������ (���ʰ������� ����ΰ�)
    public float Reroad; // ���� �ӵ�
}
