using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    // ������ ����� ������ ����

    // ���� ü��
    public int Hp;
    // ���ݷ�
    public int Dmg;
    // ���ݼӵ�
    public float AttackSpeed;
    // �̵��ӵ�
    public float MoveSpeed;

    public float attackDelay;  // ���� ������. ���콺 Ŭ���ϴ� ���� ���� ������ �� �����Ƿ�.

    public float attackDelayA;  // ���� Ȱ��ȭ ����. ���� �ִϸ��̼� �߿��� �ָ��� �� �������� �� ���� ���� �������� ���� �Ѵ�.

    public float attackDelayB;  // ���� ��Ȱ��ȭ ����. ���� �� ������ �ָ��� ���� �ִϸ��̼��� ���۵Ǹ� ���� �������� ���� �ȵȴ�.
    //���ݹ��� (��� ��ġ��  �����ϸ� ����
    public float Range;

    // �νĹ���
    public float TargetRange;

    public float DieDelay;
    // ����� �ִϸ��̼�
    public Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
}
