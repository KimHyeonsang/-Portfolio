using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombiObjectManager : MonoBehaviour
{
    private static ZombiObjectManager Instance = null;

    public int MaxNomalZombi = 60;
    public int MaxSpeedZombi = 25;
    public int MaxTankerZombi = 15;
    public static ZombiObjectManager GetInstance
    {
        get
        {
            if(Instance == null)
            {
                Instance = new ZombiObjectManager();
            }
            return Instance;
        }
    }

    // ** ���� ���� �ϴ� ����Ʈ
    private List<GameObject> EnableList = new List<GameObject>();

    public List<GameObject> GetEnableList
    {
        get
        {
            return EnableList;
        }
    }

    // ���� ������ �ݺ�
    private Stack<GameObject> DisableList = new Stack<GameObject>();

    public Stack<GameObject>GetDisableList
    {
        get
        {
            return DisableList;
        }
    }

    
}
