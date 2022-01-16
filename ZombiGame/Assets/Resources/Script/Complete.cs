using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Complete : MonoBehaviour
{
    public GameObject Obj;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Obj.SetActive(true);
            Time.timeScale = 0;
        }
    }
}
