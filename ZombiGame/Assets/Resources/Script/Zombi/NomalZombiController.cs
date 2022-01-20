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

    public GameObject[] pointPos;
    private bool Moving = false;
    private void Awake()
    {
        view = GetComponent<Zombiview>();
        zombi = GetComponent<Zombi>();
    }

    private void Start()
    {
        Target = GameObject.FindWithTag("Player");

        pointPos = GameObject.FindGameObjectsWithTag("Node");

        for(int i=0;i<pointPos.Length;++i)
        {
            Debug.Log(pointPos[i].transform.position);
        }
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
    private void  GetDirection()
    {
        Moving = true;
     //   Vector3 Node = WayPointManager.GetInstance().TargetPoint;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "Node")
        {
            int NodeNumber = WayPointManager.GetInstance().NodeNumber;
 
            ++NodeNumber;
            Moving = false;
 
            if (NodeNumber > 3)
            {
                NodeNumber = 0;
            }
            WayPointManager.GetInstance().NodeNumber = NodeNumber;
            WayPointManager.GetInstance().TargetPoint = WayPoint.WayPointList[0].transform.GetChild(NodeNumber).transform.position;
            //   WayPointManager.GetInstance().TargetPoint = WayPointList[NodeNumber].transform.position;
        }
    }
}
