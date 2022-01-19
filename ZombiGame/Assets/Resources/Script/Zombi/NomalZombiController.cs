using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalZombiController : ZombiControl
{
    private Zombiview view;
    private Zombi zombi;

    [SerializeField] private GameObject Target;
    public static bool isActivate = true;
    public static bool isMoveActivate = false;

    private bool Moving = false;
    private Vector3 WaypointTarget;
    private void Awake()
    {
        view = GetComponent<Zombiview>();
        zombi = GetComponent<Zombi>();
    }

    private void Start()
    {
        Target = GameObject.FindWithTag("Player");
 //       WaypointTarget = WayPointManager.GetInstance().TargetPoint;
    }

    private void Update()
    {
        // 만약 공격 범위 사거리 안에 들어오면
        if (zombi.Range > Vector3.Distance(Target.transform.position, transform.position))
        {
            if (isActivate)
                TryAttack();
        }        
        // 인식 범위 안에 들어오면        
        else if (isMoveActivate)
        {
            TryMove();
            transform.LookAt(Target.transform);
            transform.position = Vector3.MoveTowards(transform.position, Target.transform.position, zombi.MoveSpeed * Time.deltaTime);
        }
 //       else if(Moving)
 //       {
 //           TryMove();
 //           transform.LookAt(WayPointManager.GetInstance().TargetPoint);
 //           transform.position = Vector3.MoveTowards(transform.position, WayPointManager.GetInstance().TargetPoint, zombi.MoveSpeed * Time.deltaTime);
 //
 //       }
 //       else
 //       {
 //           GetDirection();
 //       }
        
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
    private void  GetDirection()
    {
        Moving = true;

        

    }

 //   private void OnCollisionEnter(Collision collision)
 //   {
 //       if (collision.transform.tag == "Node")
 //       {
 //           int NodeNumber = WayPointManager.GetInstance().NodeNumber;
 //
 //           ++NodeNumber;
 //           Moving = false;
 //
 //           if (NodeNumber > 5)
 //           {
 //               NodeNumber = 0;
 //           }
 //           WayPointManager.GetInstance().NodeNumber = NodeNumber;
 //           WayPointManager.GetInstance().TargetPoint = WayPoint.WayPointList[WayPointManager.GetInstance().NodeNumber].transform.position; ;
 //           //   WayPointManager.GetInstance().TargetPoint = WayPointList[NodeNumber].transform.position;
 //       }
 //   }
}
