using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZombiControl : MonoBehaviour
{
    // 좀비 컨트롤의 공통적인 기능

    [SerializeField]
    protected Zombi currentZombi; // 현재 좀비 

    protected bool isAttack = false;  // 현재 공격 중인지 
    protected bool isSwing = false;  // 팔을 휘두르는 중인지. isSwing = True 일 때만 데미지를 적용할 것이다.
    protected bool isSpeed = false; // 적이 보이면 이동
    protected RaycastHit hitInfo;  // 현재 좀비 공격에 닿은 것들의 정보.

    
    // 공격시도
    protected void TryAttack()
    {       
        if (!isAttack)
        {
            StartCoroutine(AttackCoroutine());
        }        
    }

    protected void MoveSpeed()
    {
        if(!isSpeed)
        {
            currentZombi.Anim.SetBool("Walk", true);
            currentZombi.Anim.SetBool("Idle", false);
        }
            
    }

    protected IEnumerator AttackCoroutine()
    {
        isAttack = true;
        currentZombi.Anim.SetTrigger("Attack");

        yield return new WaitForSeconds(currentZombi.attackDelayA);
        isSwing = true;

        StartCoroutine(HitCoroutine());

        yield return new WaitForSeconds(currentZombi.attackDelayB);
        isSwing = false;

        yield return new WaitForSeconds(currentZombi.attackDelay - currentZombi.attackDelayA - currentZombi.attackDelayB);
        isAttack = false;
    }

    // 공격에 맞은 오브젝트가 무엇인지 확인한다.
    protected bool CheckObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, currentZombi.Range))
        {
            return true;
        }

        return false;
    }
    protected abstract IEnumerator HitCoroutine();

  
}
