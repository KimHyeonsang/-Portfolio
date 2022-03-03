using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Assault : CloseWeaponController
{
    //false는 평시 true는 장전중
    private bool check;

    public AudioClip ShootClip;
    public AudioClip ReroadClip;
    private AudioSource AudioSound;
    void Start()
    {
        currentWeapon = GetComponent<CloseWeapon>();
        // 현재 탄약수는  최대탄창수에 맞춘다.
        currentWeapon.CurrentMagazine = currentWeapon.Magazine;

        MagazineText = GameObject.Find("Magazine").GetComponent<Text>();
        CurrentMagazine = GameObject.Find("CurrentMagazine").GetComponent<Text>();

        // 최대로 들고 있는 탄창수
        MagazineText.text = currentWeapon.MaxBullet.ToString();
        CurrentMagazine.text = currentWeapon.CurrentMagazine.ToString();

        HitEffect = Resources.Load("Effect/WFX_BImpact Concrete") as GameObject;

        Effect = GameObject.Find("assault").transform.GetChild(0).gameObject;
        currentWeapon.muzzleFlash = Effect.GetComponent<ParticleSystem>();

        check = false;

        ShootClip = Resources.Load("Sound/guns/shoot em up") as AudioClip;
        ReroadClip = Resources.Load("Sound/guns/they shoot") as AudioClip;


        AudioSound = gameObject.GetComponent<AudioSource>();
        AudioSound.Stop();
        AudioSound.clip = ShootClip;
        AudioSound.loop = false;
        AudioSound.playOnAwake = false;
    }

    void Update()
    {        
        if (Input.GetKey(KeyCode.R) && check == false)
        {  
            StartCoroutine(GunReroad());
        }

        if(Input.GetMouseButtonDown(0) && check == false)
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
        // 총을 쏘면
        if (isSwing == true)
        {
            AudioSound.clip = ShootClip;
            AudioSound.Play();
            if (CheckObject())
            {
                isSwing = false;
                // 만약 부딪힌 tag가 Enumy이면
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
        AudioSound.clip = ReroadClip;

        if (!AudioSound.isPlaying)
        {
            AudioSound.Play();
        }

        yield return new WaitForSeconds(currentWeapon.Reroad);

        // 최대총알이 0 이상일 경우
        if (currentWeapon.MaxBullet > 0)
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

        check = false;
    }
}
