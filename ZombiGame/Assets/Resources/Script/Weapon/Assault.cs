using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assault : CloseWeaponController
{
    void Start()
    {
        currentWeapon = GetComponent<CloseWeapon>();
        // 현재 탄약수는  최대탄창수에 맞춘다.
        currentWeapon.CurrentMagazine = currentWeapon.Magazine - 1;

        MagazineText = GameObject.Find("Magazine").GetComponent<Text>();
        CurrentMagazine = GameObject.Find("CurrentMagazine").GetComponent<Text>();

        // 최대로 들고 있는 탄창수
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
        // 총을 쏘면
        while (isSwing)
        {
            
            isSwing = false;
            yield return null;
        }
    }
    protected override IEnumerator GunReroad()
    {
        yield return new WaitForSeconds(currentWeapon.Reroad);

        
        // 최대총알이 0 이상일 경우
        if(currentWeapon.MaxBullet > 0)
        {
            // 최대 총알이 0일경우
            if (currentWeapon.MaxBullet < 0)
                currentWeapon.MaxBullet = 0;
            else
            {
                // 총의 총알에서 현재 들고있는 총알을 뺀다
                int Num = currentWeapon.Magazine - currentWeapon.CurrentMagazine;
                // 뺀값만큼 소모한다.
                currentWeapon.MaxBullet -= Num;
                // 현재 총알은 한탄창만큼 장전된다.
                currentWeapon.CurrentMagazine = currentWeapon.Magazine;
            }
        }


    }
}
