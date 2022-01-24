using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeapon : MonoBehaviour
{
    public int Damage; // ���ݷ�
    public float MaxRange; // �ִ� ��Ÿ�
    public float AttackDelay; // ���� ������ (���ʰ������� ����ΰ�)
    public float Reroad; // ���� �ӵ�
    public float attackDelay;  // ���� ������. ���콺 Ŭ���ϴ� ���� ���� ������ �� �����Ƿ�.
    public float attackDelayA;  // ���� Ȱ��ȭ ����. ���� �ִϸ��̼� �߿��� �ָ��� �� �������� �� ���� ���� �������� ���� �Ѵ�.
    public float attackDelayB;  // ���� ��Ȱ��ȭ ����. ���� �� ������ �ָ��� ���� �ִϸ��̼��� ���۵Ǹ� ���� �������� ���� �ȵȴ�.

    public Transform FireTransform;
    // �ִ� ������
    [Tooltip("�ִ� źâ ������")]
    public int MaxBullet;
    // źâ �뷮
    public int Magazine;
    // ���� źâ
    public int CurrentMagazine;

    public Animator Anim;

}
