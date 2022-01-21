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

        WayPointTarget = WayPoint.WayPointList[NodeNumber].transform.position;



        // ���° ������� ����
        //   for (int i = 0; i < WayPoint.WayPointList.Count; ++i)
        //   {
        //       Debug.Log(WayPoint.WayPointList[i].transform.position);
        //   }

        //   Debug.Log(WayPoint.WayPointList.Count);

        //    pointPos[0].transform.position = WayPoint.WayPointList[WayPointManager.GetInstance().NodeNumber].transform.position;
        //    WayPointManager.GetInstance().TargetPoint = WayPoint.WayPointList[0].transform.GetChild(0).transform.position;
        //   Debug.Log(WayPointManager.GetInstance().TargetPoint);
    }

    private void Update()
    {
        // ���� ���� ���� ��Ÿ� �ȿ� ������
        if (zombi.Range > Vector3.Distance(Target.transform.position, transform.position))
        {
            if (isActivate)
                TryAttack();
        }        
        // �ν� ���� �ȿ� ������        
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
       
       }
        
    }

    // ������ �ϸ�
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
                NodeNumber = 0;
            }
            WayPointTarget = WayPoint.WayPointList[NodeNumber].transform.position;
        }

     //   if(collision.transform.tag == "Ground")
     //   {
     //       this.transform.localEulerAngles = new Vector3(0, this.transform.rotation.y, 0);
     //   }

   }
 
}
