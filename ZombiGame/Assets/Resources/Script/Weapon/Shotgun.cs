using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shotgun : CloseWeaponController
{
    //false�� ��� true�� ������
    private bool check;
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

        Effect = GameObject.Find("shotgun").transform.GetChild(0).gameObject;
        currentWeapon.muzzleFlash = Effect.GetComponent<ParticleSystem>();

        check = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(GunReroad());
        }
        else if (Input.GetMouseButtonDown(0) && check == false)
        {
            if (currentWeapon.CurrentMagazine <= 0)
            {
                StartCoroutine(GunReroad());
                return;
            }
         
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
                Destroy(clone, 0.5f);
            }
            Effect.SetActive(true);
            currentWeapon.muzzleFlash.Play();
            --currentWeapon.CurrentMagazine;

            yield return null;
        }
    }
    protected override IEnumerator GunReroad()
    {
        check = true;

        Effect.SetActive(false);

        yield return new WaitForSeconds(currentWeapon.Reroad);

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

        check = false;
    }
}
