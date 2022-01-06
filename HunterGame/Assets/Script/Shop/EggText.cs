using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EggText : MonoBehaviour
{
    public Text EggOpenText;
    private GameObject TargetButton;
    void Start()
    {
        switch (TargetButton.name)
        {
            case "OneButton":
                EggOpenText.text = "200다이아로 오픈하시겠습니까?";
                break;
            case "TenButton":
                EggOpenText.text = "2000다이아로 오픈하시겠습니까?";
                break;
        }
    }

    void Update()
    {
        switch (TargetButton.name)
        {
            case "OneButton":
                EggOpenText.text = "200다이아로 오픈하시겠습니까?";
                break;
            case "TenButton":
                EggOpenText.text = "2000다이아로 오픈하시겠습니까?";
                break;
        }
    }

    public void OnClick(GameObject _Target)
    {
        TargetButton = _Target;
    }
}
