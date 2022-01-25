using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NomalBullet : MonoBehaviour
{
    private RaycastHit hitInfo;  // 현재 무기(Hand)에 닿은 것들의 정보

    public float Range;
    private int bulletSpeed;
    void Start()
    {
        bulletSpeed = 10;
    }

    void Update()
    {
    //   if(CheckObject())
    //   {
    //       GetComponent<Rigidbody>().velocity = transform.forward * bulletSpeed;
    //   }
    }

    private bool CheckObject()
    {
        if (Physics.Raycast(transform.position, transform.forward, out hitInfo, Range))
        {
            if (hitInfo.transform.tag == "Enumy")
                Destroy(this.gameObject);
            return true;
        }

        return false;
    }
}
