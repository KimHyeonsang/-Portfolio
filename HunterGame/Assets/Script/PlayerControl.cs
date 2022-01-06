using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class PlayerControl : MonoBehaviour , IDragHandler, IPointerUpHandler, IPointerDownHandler
{
    public Camera MainCamera;

    [SerializeField] private Transform Target;
    [SerializeField] private RectTransform Stick;
    [SerializeField] private RectTransform BackBoard;

    private float Radius = 0.0f;

    private float Speed = 0.0f;

    private bool TouchCheck = false;

    private Vector2 Direction;

    private Vector3 Movement;
    void Start()
    {
        Radius = (BackBoard.rect.width / 2.0f);
        MainCamera.transform.position = new Vector3(0.0f, 10.0f, Target.position.z);
        Speed = 5.0f;
    }

    void Update()
    {
        if (TouchCheck)
        {
            Target.position += Movement;
            // 메인 카메라 이동
            MainCamera.transform.position = new Vector3(Target.position.x, 10.0f, Target.position.z);

            //카메라 범위밖이동불가
        }
    }

    private void GetMovement(Vector2 _Point)
    {
        Stick.localPosition = new Vector2(
            _Point.x - BackBoard.position.x,
            _Point.y - BackBoard.position.y);

        Stick.localPosition = Vector2.ClampMagnitude(
            Stick.localPosition, Radius);

        // 비율 구현
        float Ratio = (BackBoard.position - Stick.position).sqrMagnitude / (Radius * Radius);

        Direction = Stick.localPosition.normalized;

        Movement = new Vector3(
            Direction.x * Speed * Ratio * Time.deltaTime,
            0.0f,
            Direction.y * Speed * Ratio * Time.deltaTime);
    }

    public void OnDrag(PointerEventData eventData)
    {
        GetMovement(eventData.position);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Stick.localPosition = Vector3.zero;
        TouchCheck = false;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GetMovement(eventData.position);
        TouchCheck = true;
    }
}
