using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankerZombiController : ZombiControl
{
    private Zombiview view;
    private Zombi zombi;

    [SerializeField] private GameObject Target;

    private Vector3[] WayPointTarget;
    private int NodeNumber;
    private int WayPointNumber;
    public static bool isActivate = true;

    // ��� ����
    private AudioClip DamageClip;
    private AudioClip AttackClip;
    private AudioClip idleClip;
    private AudioSource AudioSound;
    private void Awake()
    {
        view = GetComponent<Zombiview>();
        zombi = GetComponent<Zombi>();
    }

    private void Start()
    {
        Target = GameObject.FindWithTag("Player");

        // ����
        AttackClip = Resources.Load("Sound/Z1-Free/Z1-V1-Attacking-Free-1") as AudioClip;
        // ���
        idleClip = Resources.Load("Sound/Z3-Free/Z3-V2-Idle-Free-1") as AudioClip;

        //������
        DamageClip = Resources.Load("Sound/Z1-Free/Z1-V1-Damaged-Free-1") as AudioClip;


        AudioSound = gameObject.GetComponent<AudioSource>();
        AudioSound.Stop();
        AudioSound.clip = idleClip;
        AudioSound.loop = false;
        AudioSound.playOnAwake = false;

        ZombiNumber = WayPointManager.GetInstance().NodeNumber;
        WayPointManager.GetInstance().NodeNumber += 1;
        NodeNumber = ZombiNumber * 3;
        WayPointTarget = new Vector3[3];
        WayPointNumber = 0;
        for (int i = 0; i < 3; ++i)
        {
            WayPointTarget[i] = WayPoint.WayPointList[NodeNumber + i].transform.position;
        }
    }

    private void Update()
    {
        // �ν� ���� �ȿ� ������        
        if (Vector3.Distance(Target.transform.position, transform.position) < zombi.TargetRange)
        {
            // ���� ���� ���� ��Ÿ� �ȿ� ������
            if (zombi.Range > Vector3.Distance(Target.transform.position, transform.position))
            {
                if (isActivate)
                    TryAttack();
            }
            // ���� ������ ������ ������
            else
            {
                AudioSound.clip = idleClip;
                Play();
                TryMove();
                transform.LookAt(Target.transform);
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, zombi.MoveSpeed * Time.deltaTime);
            }

        }
        // Ÿ���� �ν� ���� ���̸� ��ȸ
        else
        {
            AudioSound.clip = idleClip;
            Play();
            TryMove();
            //�̵�
            transform.LookAt(WayPointTarget[WayPointNumber]);

            transform.position = Vector3.MoveTowards(transform.position, WayPointTarget[WayPointNumber], zombi.MoveSpeed * Time.deltaTime);

            if ((WayPointTarget[WayPointNumber] - transform.position).sqrMagnitude < 1.0f)
            {
                ++WayPointNumber;

                if (WayPointNumber > 2)
                {
                    WayPointNumber = 0;
                }
            }
        }

        if (zombi.Hp <= 0)
        {
            PlayerContorl.ZombiKill++;
            GetComponent<TankerZombiController>().enabled = false;
            StartCoroutine(Die());

        }
        currentZombi.Anim.SetFloat("Speed", 2.0f);
    }

    // ������ �ϸ�
    protected override IEnumerator HitCoroutine()
    {
        while (isSwing)
        {
            AudioSound.clip = AttackClip;
            Play();
            Target.GetComponent<PlayerHpControl>().ZombiDmg(zombi.Dmg);
            
            isSwing = false;
            yield return null;
        }
    }

    public void Play()
    {
        if (!AudioSound.isPlaying)
            AudioSound.Play();
    }

    public void DamegeSound()
    {
        AudioSound.clip = DamageClip;
    }
}
