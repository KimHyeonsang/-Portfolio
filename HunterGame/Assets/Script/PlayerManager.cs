using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager
{
    static private PlayerManager Instance = null;
    static public PlayerManager Getinstace
    {
        get
        {
            if (Instance == null)
                Instance = new PlayerManager();

            return Instance;
        }
    }

    public void FindPlayer(GameObject _Obj,int _Dmg)
    {
        if(_Obj.name == "Bird 4 Yellow_0(Clone)")
            _Obj.GetComponent<Attacker>().Hit(_Dmg);        
        else if(_Obj.name == "Bird5_LightYellow(Clone)")
            _Obj.GetComponent<Tanker>().Hit(_Dmg);
        else if (_Obj.name == "B1 Red Sheet_0(Clone)")
            _Obj.GetComponent<producer>().Hit(_Dmg);
    }
}
