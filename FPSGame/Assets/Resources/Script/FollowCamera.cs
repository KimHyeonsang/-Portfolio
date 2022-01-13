using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    private GameObject Target;

    private float TurnSpeed;
    private Vector3 Offset;
    private float xRotate = 0.0f;

    private void Awake()
    {
        Target = GameManager.GetInstance.Spawn();
    }
    void Start()
    {
        TurnSpeed = 4.0f;
        Offset = new Vector3(0.0f, 1.8f, 0.0f);
    }

    
    void Update()
    {
        float yRotateSize = Input.GetAxis("Mouse X") * TurnSpeed;
        // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
        float yRotate = transform.eulerAngles.y + yRotateSize;

        float xRotateSize = -Input.GetAxis("Mouse Y") * TurnSpeed;
        // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ����
        // Clamp �� ���� ������ �����ϴ� �Լ�
        xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 80);

        // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
        transform.eulerAngles = new Vector3(xRotate, yRotate, 0);

        transform.position = Target.transform.position + Offset;
    }
}
