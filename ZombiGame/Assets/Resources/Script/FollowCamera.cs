using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Target;

    private float TurnSpeed;
    private Vector3 Offset;
    private float xRotate = 0.0f;

    // ** 플레이어를 메인 카메라에서 안보이게 하기  위함.
    private LayerMask PlayerMask;
    private Camera MainCamera;
    private void Awake()
    {
        Target = GameManager.GetInstance.Spawn();

        MainCamera = GetComponent<Camera>();

    //    PlayerMask = LayerMask.NameToLayer("Player");
    //    MainCamera.cullingMask = (-1) - (1 << PlayerMask);
    }
    void Start()
    {
        TurnSpeed = 4.0f;
        Offset = new Vector3(0.0f, 1.8f, 0.0f);
    }

    
    void Update()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * TurnSpeed;
        // 현재 y축 회전값에 더한 새로운 회전각도 계산
        float yRotate = transform.eulerAngles.y + yRotateSize;

    //    float xRotateSize = -Input.GetAxis("Mouse Y") * TurnSpeed;
    //    // 위아래 회전량을 더해주지만 -45도 ~ 80도로 제한
    //    // Clamp 는 값의 범위를 제한하는 함수
    //    xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 30);

        // 카메라 회전량을 카메라에 반영(X, Y축만 회전)
    //    transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        transform.eulerAngles = new Vector3(0, yRotate, 0);

        transform.position = Target.transform.position + Offset;
    }
}
