using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggBuy : MonoBehaviour
{
    public GameObject One;
    public GameObject Ten;
    private EggOpen Egg;

    private void Start()
    {
        Egg = GameObject.Find("EggBuy").GetComponent<EggOpen>();
        
    }
    public void OnCheck()
    {
        if(Egg.One)
        {
            One.SetActive(true);
            Ten.SetActive(false);
            Egg.RandomEggOpen();
        }
        if(Egg.Ten)
        {
            Ten.SetActive(true);
            One.SetActive(false);
            Egg.RandomTenEggOpen();
        }
    }
    
}
