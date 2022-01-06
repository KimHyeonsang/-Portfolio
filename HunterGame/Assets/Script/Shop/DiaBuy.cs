using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DiaBuy : MonoBehaviour
{
    [SerializeField] private GameObject TargetButton;
    public static Text SeclectText;
    public Text Dia1Text;
    public Text Dia2Text;
    public Text Dia3Text;
    public Text Dia4Text;
    void Start()
    {
        switch(TargetButton.name)
        {
            case "Dia1Button":
                SeclectText = Dia1Text;
                break;
            case "Dia2Button":
                SeclectText = Dia2Text;
                break;
            case "Dia3Button":
                SeclectText = Dia3Text;
                break;
            case "Dia4Button":
                SeclectText = Dia4Text;
                break;
        }
    }

    void Update()
    {
        switch (TargetButton.name)
        {
            case "Dia1Button":
                SeclectText = Dia1Text;
                break;
            case "Dia2Button":
                SeclectText = Dia2Text;
                break;
            case "Dia3Button":
                SeclectText = Dia3Text;
                break;
            case "Dia4Button":
                SeclectText = Dia4Text;
                break;
        }
    }
    public void BuyButton()
    {
        GameManager.GetInstance.Dia += int.Parse(SeclectText.text);
    }
    public void ClickButton(GameObject _Target)
    {
        TargetButton = _Target;
    }
}
