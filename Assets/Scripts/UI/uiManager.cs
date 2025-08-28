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

    // UI ��Ÿ���� �ϱ�
    public void ShowUI(CanvasGroup group)
    {
        group.gameObject.SetActive(true);
        group.interactable = true;
        group.blocksRaycasts = true;

        group.alpha = 0f; // ó���� ����
        group.DOFade(1f, fadeDuration)
             .SetEase(Ease.InOutQuad);
    }

    // UI ������� �ϱ�
    public void HideUI(CanvasGroup group)
    {
        group.interactable = false;
        group.blocksRaycasts = false;

        group.DOFade(0f, fadeDuration)
             .SetEase(Ease.InOutQuad)
             .OnComplete(() => group.gameObject.SetActive(false));
    }

    // ��ü ��ȯ: �ϳ��� �������, �ϳ��� ��Ÿ���� ����
    public void Transition(CanvasGroup fromGroup, CanvasGroup toGroup)
    {
        HideUI(fromGroup);
        ShowUI(toGroup);
    }
}