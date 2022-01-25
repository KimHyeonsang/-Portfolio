using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowWeaponCamera : MonoBehaviour
{
    [SerializeField] private GameObject Target;
    private Vector3 Offset;

    [SerializeField] private Camera MainCamera;
    private float TurnSpeed;
    private float xRotate = 0.0f;
    void Start()
    {
        TurnSpeed = 4.0f;
        MainCamera = Camera.main;
        Target = MainCamera.GetComponent<FollowCamera>().Target;
        Offset = new Vector3(0.0f, 1.8f, 0.0f);
    }

    // Update is called once per frame
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
        transform.eulerAngles = new Vector3(0, yRotate, 0);
        transform.position = Target.transform.position + Offset;
    }
}
