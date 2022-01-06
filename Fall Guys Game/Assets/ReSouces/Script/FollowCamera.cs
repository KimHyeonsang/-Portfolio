using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Target;

    public float Distance;

    [SerializeField] private Vector3 Offset;
       
    void Start()
    {
        Offset = new Vector3(0.0f, 5.0f, -8.0f);
    }

    void Update()
    {
        Vector3 Direction = Target.transform.forward;

        Distance = 0.5f;
        Direction.z *= -5;
    //    Direction.y *= 5;
    //
        transform.position = Direction + Target.transform.position;

        Distance = Mathf.Clamp(Distance, 0.0f, 1.0f);

        transform.position = Vector3.Lerp(
           Target.transform.position,
           Target.transform.position + Offset,
           Distance);
        // 카메라가 타겟을 부드럽게 바라봄
        transform.rotation = Quaternion.Lerp(
            transform.rotation,
            Quaternion.LookRotation((Target.transform.position - transform.position).normalized),
            Time.deltaTime);
    }
}
