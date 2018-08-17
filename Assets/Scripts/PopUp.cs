using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class PopUp :MonoBehaviour
{
    private CanvasGroup canvasGroup;

    [SerializeField] 
    private float transitionTime = 0.5f;

    [SerializeField] 
    private bool showOnStart = false;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }

    private void OnEnable()
    {
        canvasGroup.alpha = 0;
        
        if (showOnStart)
        {
            Show();
        }
        else
        {
            Close();
        }
       
    }

    public void Show()
    {
        
        PauseScript.canPause = false;
        
        canvasGroup.blocksRaycasts = true;
        canvasGroup.interactable = true;

        canvasGroup.DOFade(1, transitionTime);
    }

    public void Close()
    {
        PauseScript.canPause = true;
        
        canvasGroup.blocksRaycasts = false;
        canvasGroup.interactable = false;

        canvasGroup.DOFade(0, transitionTime);
    }
    
}
