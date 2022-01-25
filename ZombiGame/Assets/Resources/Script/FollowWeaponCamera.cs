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
        // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
        float yRotate = transform.eulerAngles.y + yRotateSize;

    //    float xRotateSize = -Input.GetAxis("Mouse Y") * TurnSpeed;
    //    // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ����
    //    // Clamp �� ���� ������ �����ϴ� �Լ�
    //    xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 30);

        // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
        transform.eulerAngles = new Vector3(0, yRotate, 0);
        transform.position = Target.transform.position + Offset;
    }
}
