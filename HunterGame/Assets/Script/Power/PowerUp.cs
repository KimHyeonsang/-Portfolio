using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PowerUp : MonoBehaviour
{    
    public void Upgrade()
    {    
        if(GameObject.Find("PlayerInfo").GetComponent<ProducerInfo>().enabled == true)
        {
            GameObject.Find("PlayerInfo").GetComponent<ProducerInfo>().PowerUp();
        }
        else if (GameObject.Find("PlayerInfo").GetComponent<AttackerInfo>().enabled == true)
        {
            GameObject.Find("PlayerInfo").GetComponent<AttackerInfo>().PowerUp();
        }
        else if (GameObject.Find("PlayerInfo").GetComponent<TankerInfo>().enabled == true)
        {
            GameObject.Find("PlayerInfo").GetComponent<TankerInfo>().PowerUp();
        }
    }
}
