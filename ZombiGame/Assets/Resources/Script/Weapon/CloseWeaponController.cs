using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeaponController : MonoBehaviour
{
    [SerializeField]
    protected CloseWeapon currentWeapon; // ���� ������ ����

    protected bool isAttack = false;  // ���� ���� ������ 
    protected bool isSwing = false;  // ���� �ֵθ��� ������. isSwing = True �� ���� �������� ������ ���̴�.

    protected RaycastHit hitInfo;  // ���� ����(Hand)�� ���� �͵��� ����.

  
    
}
