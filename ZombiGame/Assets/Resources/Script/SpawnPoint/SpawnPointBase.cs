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
                Random.Range(WayPointManager.GetInstance().WayPointA.x, WayPointManager.GetInstance().WayPointB.x),
                0.0f,
               Random.Range(WayPointManager.GetInstance().WayPointA.y, WayPointManager.GetInstance().WayPointB.y));
        }
        else
        {
            Destroy(this.gameObject.GetComponent<Rigidbody>());
            Destroy(this.gameObject.GetComponent<BoxCollider>());
            this.GetComponent<Rigidbody>().useGravity = false;
            this.GetComponent<Rigidbody>().isKinematic = true;
        }
        
    }
    
}
