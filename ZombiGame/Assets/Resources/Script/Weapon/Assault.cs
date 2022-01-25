using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assault : CloseWeaponController
{
    private GameObject Bullet;
    private GameObject Obj;


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

        Bullet = Resources.Load("Prefabs/Bullet/Sphere") as GameObject;

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
            isSwing = false;
            Obj = Instantiate(Bullet, transform.position, transform.rotation);
            Obj.transform.position = GameObject.FindGameObjectsWithTag("CreatBullet")[0].transform.position;

            Obj.GetComponent<NomalBullet>().Range = currentWeapon.MaxRange;
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
