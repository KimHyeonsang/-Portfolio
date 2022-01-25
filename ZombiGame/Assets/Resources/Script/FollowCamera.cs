using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public GameObject Target;

    private float TurnSpeed;
    private Vector3 Offset;
    private float xRotate = 0.0f;

    // ** �÷��̾ ���� ī�޶󿡼� �Ⱥ��̰� �ϱ�  ����.
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
        // ���� y�� ȸ������ ���� ���ο� ȸ������ ���
        float yRotate = transform.eulerAngles.y + yRotateSize;

    //    float xRotateSize = -Input.GetAxis("Mouse Y") * TurnSpeed;
    //    // ���Ʒ� ȸ������ ���������� -45�� ~ 80���� ����
    //    // Clamp �� ���� ������ �����ϴ� �Լ�
    //    xRotate = Mathf.Clamp(xRotate + xRotateSize, -45, 30);

        // ī�޶� ȸ������ ī�޶� �ݿ�(X, Y�ุ ȸ��)
    //    transform.eulerAngles = new Vector3(xRotate, yRotate, 0);
        transform.eulerAngles = new Vector3(0, yRotate, 0);

        transform.position = Target.transform.position + Offset;
    }
}
