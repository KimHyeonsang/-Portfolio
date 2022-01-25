using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CloseWeaponController : MonoBehaviour
{
    [SerializeField]
    protected CloseWeapon currentWeapon; // ���� ������ ����

    protected bool isAttack = false;  // ���� ���� ������ 
    protected bool isSwing = false;  // ���� �ֵθ��� ������. isSwing = True �� ���� �������� ������ ���̴�.

    protected Text MagazineText;
    protected Text CurrentMagazine;

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

        yield return new WaitForSeconds(currentWeapon.attackDelayA);
        isSwing = true;

        StartCoroutine(HitCoroutine());

        yield return new WaitForSeconds(currentWeapon.attackDelayB);
        isSwing = false;

        yield return new WaitForSeconds(currentWeapon.attackDelay - currentWeapon.attackDelayA - currentWeapon.attackDelayB);
        isAttack = false;
    }

    // ���ݿ� ���� ������Ʈ�� �������� Ȯ���Ѵ�.
   
    protected abstract IEnumerator HitCoroutine();
    protected abstract IEnumerator GunReroad();
}
