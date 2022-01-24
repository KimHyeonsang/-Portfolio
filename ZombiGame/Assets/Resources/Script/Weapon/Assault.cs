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
        currentWeapon.CurrentMagazine = currentWeapon.Magazine - 1;

        MagazineText = GameObject.Find("Magazine").GetComponent<Text>();
        CurrentMagazine = GameObject.Find("CurrentMagazine").GetComponent<Text>();

        // �ִ�� ��� �ִ� źâ��
        MagazineText.text = currentWeapon.MaxBullet.ToString();
        CurrentMagazine.text = currentWeapon.CurrentMagazine.ToString();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            StartCoroutine(GunReroad());
        }

        MagazineText.text = currentWeapon.MaxBullet.ToString();
        CurrentMagazine.text = currentWeapon.CurrentMagazine.ToString();
    }
    protected override IEnumerator HitCoroutine()
    {
        // ���� ���
        while (isSwing)
        {
            
            isSwing = false;
            yield return null;
        }
    }
    protected override IEnumerator GunReroad()
    {
        yield return new WaitForSeconds(currentWeapon.Reroad);

        
        // �ִ��Ѿ��� 0 �̻��� ���
        if(currentWeapon.MaxBullet > 0)
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
