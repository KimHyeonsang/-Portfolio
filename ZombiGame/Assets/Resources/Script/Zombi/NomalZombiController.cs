using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalZombiController : ZombiControl
{
    private Zombiview view;
    private Zombi zombi;

    [SerializeField] private GameObject Target;

    private Vector3 WayPointTarget;
    private int NodeNumber;
    private int WayPointNumber;
    public static bool isActivate = true;
    public static bool isMoveActivate = false;

    private bool Moving = true;
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

     //   Debug.Log(WayPoint.WayPointList[NodeNumber].transform.position);
     //   Debug.Log(WayPoint.WayPointList[NodeNumber + 1].transform.position);
     //   Debug.Log(WayPoint.WayPointList[NodeNumber + 2].transform.position);
           
        
         WayPointTarget = WayPoint.WayPointList[NodeNumber].transform.position;

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

       else if(Moving)
       {
           TryMove();
           transform.LookAt(WayPointTarget);
           transform.position = Vector3.MoveTowards(transform.position, WayPointTarget, zombi.MoveSpeed * Time.deltaTime);

           if(Vector3.Distance(WayPointTarget, transform.position)== 0.0f)
           {
               ++NodeNumber;
       
               if (NodeNumber > ((ZombiNumber + 1) * 3) - 1)
               {
                   NodeNumber = ZombiNumber * 3;
               }
           }
       
       }


        if (zombi.Hp <= 0)
        {
            GetComponent<NomalZombiController>().enabled = false;
            StartCoroutine(Die());

        }
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


 private void OnCollisionEnter(Collision collision)
 {
      if(WayPointTarget == collision.transform.position)
      {
          ++NodeNumber;

          if (NodeNumber > ((ZombiNumber + 1) * 3) - 1)
          {
              NodeNumber = ZombiNumber * 3;
          }
          WayPointTarget = WayPoint.WayPointList[NodeNumber].transform.position;
      }

   //   if(collision.transform.tag == "Ground")
   //   {
   //       this.transform.localEulerAngles = new Vector3(0, this.transform.rotation.y, 0);
   //   }

 }
 //
 //  private void OnTriggerEnter(Collider other)
 //  {
 //      if (WayPointTarget == other.transform.position)
 //      {
 //          ++NodeNumber;
 //
 //          if (NodeNumber > ((ZombiNumber + 1) * 3) - 1)
 //          {
 //              NodeNumber = ZombiNumber * 3;
 //          }
 //          WayPointTarget = WayPoint.WayPointList[NodeNumber].transform.position;
 //      }
 //  }
}
