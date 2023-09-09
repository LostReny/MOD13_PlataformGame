using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class MenuButtonsManager : MonoBehaviour
{
    public List<GameObject> menuButtons;

    [Header("Animation Setup")]
    public float duration = 2f;
    public float delay = 0.05f;
    public Ease ease = Ease.OutBack;


    private void OnEnable() {
        HideButtons();
        ShowButtons();
    }


    private void HideButtons(){
        foreach (var b in menuButtons) {
            b.transform.localScale = Vector3.zero;
            b.SetActive(false);
        }
    }


    private void ShowButtons(){
        for(int  i = 0; i < menuButtons.Count; i++){
            var b = menuButtons[i];
            b.SetActive(true);
            b.transform.DOScale(1, duration).SetDelay(i*delay).SetEase(ease);
        }
    }

}
