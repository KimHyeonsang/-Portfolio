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

    protected RaycastHit hitInfo;  // ���� ����(Hand)�� ���� �͵��� ����.

    protected GameObject Effect;
    protected GameObject HitEffect;
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
    protected bool CheckObject()
    {
        if (Physics.Raycast(transform.GetChild(0).transform.position, transform.forward, out hitInfo, currentWeapon.MaxRange))
        {
            if (hitInfo.transform.name == "NomalZombi")
            {
                if (hitInfo.transform.GetComponent<Zombi>().Hp > 0)
                {
                    hitInfo.transform.GetComponent<Zombi>().Hp -= currentWeapon.Damage;

                }
            }
            else if (hitInfo.transform.name == "TankerZombi")
            {
                if (hitInfo.transform.GetComponent<Zombi>().Hp > 0)
                {
                    hitInfo.transform.GetComponent<Zombi>().Hp -= currentWeapon.Damage;

                }
            }
            else if (hitInfo.transform.name == "SpeedZombi")
            {
                if (hitInfo.transform.GetComponent<Zombi>().Hp > 0)
                {
                    hitInfo.transform.GetComponent<Zombi>().Hp -= currentWeapon.Damage;
                }
            }

            Debug.DrawLine(transform.position, hitInfo.point, Color.red);
            Effect.SetActive(false);
            currentWeapon.muzzleFlash.Stop();
            return true;
        }

        Effect.SetActive(false);
        currentWeapon.muzzleFlash.Stop();
        return false;
    }
    protected abstract IEnumerator HitCoroutine();
    protected abstract IEnumerator GunReroad();
}
