using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class uiManager : SingletonMono<uiManager>
{
    public float fadeDuration = 0.5f;

    // UI 나타나게 하기
    public void ShowUI(CanvasGroup group)
    {
        group.gameObject.SetActive(true);
        group.interactable = true;
        group.blocksRaycasts = true;

        group.alpha = 0f; // 처음엔 투명
        group.DOFade(1f, fadeDuration)
             .SetEase(Ease.InOutQuad);
    }

    // UI 사라지게 하기
    public void HideUI(CanvasGroup group)
    {
        group.interactable = false;
        group.blocksRaycasts = false;

        group.DOFade(0f, fadeDuration)
             .SetEase(Ease.InOutQuad)
             .OnComplete(() => group.gameObject.SetActive(false));
    }

    // 전체 전환: 하나는 사라지고, 하나는 나타나는 구조
    public void Transition(CanvasGroup fromGroup, CanvasGroup toGroup)
    {
        HideUI(fromGroup);
        ShowUI(toGroup);
    }
}