using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrossHair : MonoBehaviour
{
    private Vector3 ScreenCenter;
    
    void Start()
    {
        transform.position = new Vector3(Camera.main.pixelWidth / 2, (Camera.main.pixelHeight / 2.2f));
    }

    void Update()
    {
    }
}
