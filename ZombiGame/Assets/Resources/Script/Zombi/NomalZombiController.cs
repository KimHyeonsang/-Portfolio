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
    private void Awake()
    {
        view = GetComponent<Zombiview>();
        zombi = GetComponent<Zombi>();
    }

    private void Start()
    {
        Target = GameObject.FindWithTag("Player");
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
}
