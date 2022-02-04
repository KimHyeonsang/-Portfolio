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

    protected int ZombiNumber;
    // ���ݽõ�
    protected void TryAttack()
    {
        currentZombi = GetComponent<Zombi>();
        if (!isAttack)
        {
            StartCoroutine(AttackCoroutine());
        }
    }

    protected void TryMove()
    {
        currentZombi = GetComponent<Zombi>();
        if (!isSpeed)
        {
            currentZombi.Anim.SetBool("Walking", true);
        }
        else
            currentZombi.Anim.SetBool("Walking", false);

    }
    protected void Idle()
    {
        currentZombi = GetComponent<Zombi>();
       
        currentZombi.Anim.SetTrigger("Idle");
       

    }
    protected IEnumerator Die()
    {
        currentZombi = GetComponent<Zombi>();
       
        currentZombi.Anim.SetBool("Die", true);

        yield return new WaitForSeconds(currentZombi.DieDelay);

        ZombiObjectManager.GetInstance.GetEnableList.Remove(this.gameObject);
        this.gameObject.SetActive(false);
        ZombiObjectManager.GetInstance.GetDisableList.Push(this.gameObject);
        Debug.Log(ZombiObjectManager.GetInstance.GetDisableList.Count);
     }
    protected IEnumerator AttackCoroutine()
    {
        isSpeed = false;
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
