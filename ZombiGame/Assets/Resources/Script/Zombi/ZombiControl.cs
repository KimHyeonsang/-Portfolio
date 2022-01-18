using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ZombiControl : MonoBehaviour
{
    // ���� ��Ʈ���� �������� ���

    [SerializeField]
    protected Zombi currentZombi; // ���� ���� 

    protected bool isAttack = false;  // ���� ���� ������ 
    protected bool isSwing = false;  // ���� �ֵθ��� ������. isSwing = True �� ���� �������� ������ ���̴�.
    protected bool isSpeed = false; // ���� ���̸� �̵�
    protected RaycastHit hitInfo;  // ���� ���� ���ݿ� ���� �͵��� ����.

    
    // ���ݽõ�
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

    // ���ݿ� ���� ������Ʈ�� �������� Ȯ���Ѵ�.
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
