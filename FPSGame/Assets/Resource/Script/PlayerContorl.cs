using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContorl : MonoBehaviour
{
    private float MoveSpeed;
    private float RunSpeed;

    public Camera cam;
    void Start()
    {
        MoveSpeed = 5.0f;
        RunSpeed = 9.0f;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(-MoveSpeed * Time.deltaTime, 0, 0);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(MoveSpeed * Time.deltaTime, 0, 0);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, MoveSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -MoveSpeed * Time.deltaTime);
        }

        // ** มกวม
        if (Input.GetKey(KeyCode.Space))
        {
            transform.Translate(0, 20 * Time.deltaTime, 0);
        }

        transform.localRotation = cam.transform.localRotation;
    }
}
