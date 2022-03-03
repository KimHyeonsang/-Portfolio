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
    public GameObject PlayerUi;
    public GameObject GameOverUi;

    private GameObject Player;
    private void Start()
    {
        Player = GameObject.FindWithTag("Player");

    }
    private void Update()
    {
        if (Player.GetComponent<PlayerHpControl>().HurrentPlayerHart <= 0)
        {
            StartCoroutine(PlayerDie());
        }
    }


    private IEnumerator PlayerDie()
    {
        yield return new WaitForSeconds(3.0f);

        Time.timeScale = 0;
        PlayerUi.SetActive(false);
        GameOverUi.SetActive(true);
    }



    IEnumerator Save()
    {
        yield return new WaitForSeconds(10.0f);
        for (int i = 0; i < ZombiObjectManager.GetInstance.GetDisableList.Count; ++i)
        {
            GameObject zombi = ZombiObjectManager.GetInstance.GetDisableList.Pop();
            ZombiObjectManager.GetInstance.GetEnableList.Add(zombi);
            Debug.Log(ZombiObjectManager.GetInstance.GetEnableList.Count);
        }
    }
}
