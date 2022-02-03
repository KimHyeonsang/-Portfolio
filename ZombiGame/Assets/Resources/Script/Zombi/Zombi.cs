using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombi : MonoBehaviour
{
    // 좀비의 공통된 정보를 저장

    // 좀비 체력
    public int Hp;
    // 공격력
    public int Dmg;
    // 공격속도
    public float AttackSpeed;
    // 이동속도
    public float MoveSpeed;

    public float attackDelay;  // 공격 딜레이. 마우스 클릭하는 순간 마다 공격할 순 없으므로.

    public float attackDelayA;  // 공격 활성화 시점. 공격 애니메이션 중에서 주먹이 다 뻗어졌을 때 부터 공격 데미지가 들어가야 한다.

    public float attackDelayB;  // 공격 비활성화 시점. 이제 다 때리고 주먹을 빼는 애니메이션이 시작되면 공격 데미지가 들어가면 안된다.
    //공격범위 (어느 위치에  도달하면 공격
    public float Range;

    // 인식범위
    public float TargetRange;

    public float DieDelay;
    // 좀비들 애니메이션
    public Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }
}
