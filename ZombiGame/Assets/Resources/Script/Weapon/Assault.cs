using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assault : CloseWeaponController
{
    
    void Start()
    {
        currentWeapon = GetComponent<CloseWeapon>();
        // ���� ź�����  �ִ�źâ���� �����.
        currentWeapon.CurrentMagazine = currentWeapon.Magazine;

        MagazineText = GameObject.Find("Magazine").GetComponent<Text>();
        CurrentMagazine = GameObject.Find("CurrentMagazine").GetComponent<Text>();

        // �ִ�� ��� �ִ� źâ��
        MagazineText.text = currentWeapon.MaxBullet.ToString();
        CurrentMagazine.text = currentWeapon.CurrentMagazine.ToString();

        HitEffect = Resources.Load("Effect/WFX_BImpact Concrete") as GameObject;

        Effect = GameObject.Find("assault").transform.GetChild(0).gameObject;
        currentWeapon.muzzleFlash = Effect.GetComponent<ParticleSystem>();
    }

    void Update()
    {        
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(GunReroad());
        }
        else if(Input.GetMouseButtonDown(0))
        {
            if (currentWeapon.CurrentMagazine <= 0)
            {
                StartCoroutine(GunReroad());
                return;
            }
            Effect.SetActive(true);
            currentWeapon.muzzleFlash.Play();
            --currentWeapon.CurrentMagazine;            
            TryAttack();
        }
        
        MagazineText.text = currentWeapon.MaxBullet.ToString();
        CurrentMagazine.text = currentWeapon.CurrentMagazine.ToString();
    }

    protected override IEnumerator HitCoroutine()
    {
        // ���� ���
        if (isSwing == true)
        {            
            if (CheckObject())
            {
                isSwing = false;
                // ���� �ε��� tag�� Enumy�̸�
                GameObject clone = Instantiate(HitEffect, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));
                Destroy(clone, 2f);
            }
            yield return null;
        }
    }
    protected override IEnumerator GunReroad()
    {
        yield return new WaitForSeconds(currentWeapon.Reroad);

        currentWeapon.muzzleFlash.Stop();
        Effect.SetActive(false);

        // �ִ��Ѿ��� 0 �̻��� ���
        if (currentWeapon.MaxBullet > 0)
        {
            // �ִ� �Ѿ��� 0�ϰ��
            if (currentWeapon.MaxBullet < 0)
                currentWeapon.MaxBullet = 0;
            else
            {
                // ���� �Ѿ˿��� ���� ����ִ� �Ѿ��� ����
                int Num = currentWeapon.Magazine - currentWeapon.CurrentMagazine;
                // ������ŭ �Ҹ��Ѵ�.
                currentWeapon.MaxBullet -= Num;
                // ���� �Ѿ��� ��źâ��ŭ �����ȴ�.
                currentWeapon.CurrentMagazine = currentWeapon.Magazine;
            }
        }
    }
}
