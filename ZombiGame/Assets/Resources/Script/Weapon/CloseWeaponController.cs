using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class CloseWeaponController : MonoBehaviour
{
    [SerializeField]
    protected CloseWeapon currentWeapon; // 현재 장착된 무기

    protected bool isAttack = false;  // 현재 공격 중인지 
    protected bool isSwing = false;  // 팔을 휘두르는 중인지. isSwing = True 일 때만 데미지를 적용할 것이다.

    protected Text MagazineText;
    protected Text CurrentMagazine;

    protected RaycastHit hitInfo;  // 현재 무기(Hand)에 닿은 것들의 정보.

    protected GameObject Effect;
    // 공격시도
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

    // 공격에 맞은 오브젝트가 무엇인지 확인한다.
    protected bool CheckObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, currentWeapon.MaxRange))
        {
            if(hitInfo.transform.tag == "Enumy")
            {
                
            }
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
