using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPointBase : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag != "Ground" && collision.transform.tag != "Player"
            && collision.transform.tag == "NoSpawn")
        {
            transform.position = new Vector3(
                Random.Range(WayPointManager.GetInstance().PointA.x, WayPointManager.GetInstance().PointB.x),
                -10.0f,
               Random.Range(WayPointManager.GetInstance().PointA.y, WayPointManager.GetInstance().PointB.y));
        }
        
    }
    
}
