﻿using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PopUp :MonoBehaviour
{
    private CanvasGroup canvasGroup;

    [SerializeField] 
    private float transitionTime = 0.5f;
    
    private void Start()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        
        Close();
    }

    public void Show()
    {
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        canvasGroup.DOFade(1, transitionTime);
    }

    public void Close()
    {
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        canvasGroup.DOFade(0, transitionTime);
    }
    
}
