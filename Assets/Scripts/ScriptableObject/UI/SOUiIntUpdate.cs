using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOUiIntUpdate : MonoBehaviour
{
    public SOInt soInt;

    public TextMeshProUGUI textMeshValue;

    public SOInt soIntLife;

    public TextMeshProUGUI textMeshValueLife;


    void Update()
    {
        UpdateUi();
        UpdateUiLife();
    }

    public void UpdateUi()
    {
        if (textMeshValue != null)
        {
            textMeshValue.text = soInt.value.ToString();
        } else return; 
    }

    public void UpdateUiLife()
    {
        if (textMeshValueLife != null)
        {
            textMeshValueLife.text = soIntLife.value.ToString();
        }
        else return;
    }
}
