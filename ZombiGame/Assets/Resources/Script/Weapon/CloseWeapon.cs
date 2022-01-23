using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseWeapon : MonoBehaviour
{
    public int Damage; // 공격력
    public float MaxRange; // 최대 사거리
    public float AttackDelay; // 공격 딜레이 (몇초간격으로 쏠것인가)
    public float Reroad; // 장전 속도
    public float attackDelay;  // 공격 딜레이. 마우스 클릭하는 순간 마다 공격할 순 없으므로.
    public float attackDelayA;  // 공격 활성화 시점. 공격 애니메이션 중에서 주먹이 다 뻗어졌을 때 부터 공격 데미지가 들어가야 한다.
    public float attackDelayB;  // 공격 비활성화 시점. 이제 다 때리고 주먹을 빼는 애니메이션이 시작되면 공격 데미지가 들어가면 안된다.
    public Animator anim;
}
