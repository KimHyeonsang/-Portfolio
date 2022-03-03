using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Complete : MonoBehaviour
{
    public GameObject Obj;


    private void Update()
    {
        if(Obj.activeSelf == true)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("MainScene");
                WayPoint.WayPointList.Clear();
                ZombiObjectManager.GetInstance.GetEnableList.Clear();
                ZombiObjectManager.GetInstance.GetDisableList.Clear();
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player")
        {
            Obj.SetActive(true);
            Time.timeScale = 0;
            GameManager.GetInstance().completecheck = true;
        }
    }

}
