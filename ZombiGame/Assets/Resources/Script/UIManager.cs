using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static UIManager Instance = null;

    public static UIManager GetInstance()
    {
        if (Instance == null)
        {
            Instance = new UIManager();

        }

        return Instance;
    }

    public Image CrossHair;
    public GameObject GButton;

    private void Start()
    {
     //   StartCoroutine("Save");
    }

    IEnumerator Save()
    {
        yield return new WaitForSeconds(10.0f);
        Debug.Log(ZombiObjectManager.GetInstance.GetDisableList.Count);
        for (int i = 0; i < ZombiObjectManager.GetInstance.GetDisableList.Count; ++i)
        {
            GameObject zombi = ZombiObjectManager.GetInstance.GetDisableList.Pop();
            ZombiObjectManager.GetInstance.GetEnableList.Add(zombi);
            Debug.Log(ZombiObjectManager.GetInstance.GetEnableList.Count);

        }
    }
}
