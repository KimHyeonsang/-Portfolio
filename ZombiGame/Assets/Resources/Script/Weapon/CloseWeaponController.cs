using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CloseWeaponController : MonoBehaviour
{
    [SerializeField]
    protected CloseWeapon currentWeapon; // ���� ������ ����

    protected bool isAttack = false;  // ���� ���� ������ 
    protected bool isSwing = false;  // ���� �ֵθ��� ������. isSwing = True �� ���� �������� ������ ���̴�.

    protected RaycastHit hitInfo;  // ���� ����(Hand)�� ���� �͵��� ����.


    // ���ݽõ�
    protected void TryAttack()
    {
        currentWeapon = GetComponent<CloseWeapon>();
        if (!isAttack)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    protected IEnumerator AttackCoroutine()
    {
        isAttack = true;
        //    currentWeapon.Anim.SetTrigger("Attack");

        yield return new WaitForSeconds(currentWeapon.attackDelayA);
        isSwing = true;

        StartCoroutine(HitCoroutine());

        yield return new WaitForSeconds(currentWeapon.attackDelayB);
        isSwing = false;

        yield return new WaitForSeconds(currentWeapon.attackDelay - currentWeapon.attackDelayA - currentWeapon.attackDelayB);
        isAttack = false;
    }

    // ���ݿ� ���� ������Ʈ�� �������� Ȯ���Ѵ�.
    protected bool CheckObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, currentWeapon.MaxRange))
        {
            return true;
        }

        return false;
    }
    protected abstract IEnumerator HitCoroutine();
}
