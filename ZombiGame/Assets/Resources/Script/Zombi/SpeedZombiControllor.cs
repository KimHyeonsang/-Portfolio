using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedZombiControllor : ZombiControl
{
    private Zombiview view;
    private Zombi zombi;

    [SerializeField] private GameObject Target;

    private Vector3[] WayPointTarget;
    private int NodeNumber;
    private int WayPointNumber;
    public static bool isActivate = true;
    private void Awake()
    {
        view = GetComponent<Zombiview>();
        zombi = GetComponent<Zombi>();
    }

    private void Start()
    {
        Target = GameObject.FindWithTag("Player");

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
        // 인식 범위 안에 들어오면        
        if (Vector3.Distance(Target.transform.position, transform.position) < zombi.TargetRange)
        {
            // 만약 공격 범위 사거리 안에 들어오면
            if (zombi.Range > Vector3.Distance(Target.transform.position, transform.position))
            {
                if (isActivate)
                    TryAttack();
            }
            // 공격 범위에 들어오지 않으면
            else
            {
                TryMove();
                transform.LookAt(Target.transform);
                transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, zombi.MoveSpeed * Time.deltaTime);
            }

        }
        // 타겟이 인식 범위 밖이면 순회
        else
        {
            TryMove();
            //이동
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
            GetComponent<SpeedZombiControllor>().enabled = false;
            StartCoroutine(Die());

        }

        currentZombi.Anim.SetFloat("Speed", 3.0f);
    }

    // 공격을 하면
    protected override IEnumerator HitCoroutine()
    {
        while (isSwing)
        {
            Target.GetComponent<PlayerHpControl>().ZombiDmg(zombi.Dmg);
            isSwing = false;
            yield return null;
        }
    }
}
