using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundColorChanger : MonoBehaviour
{
    private Camera cam;

    private readonly Dictionary<int, Color> colorDicitonary = new Dictionary<int, Color>();

    [SerializeField] 
    private float transitionTime = 2f;

    public List<BackgroundColor> colorList = new List<BackgroundColor>();

    private int currentRanomIndex;

    // Use this for initialization
    private void Start()
    {
        AssignIntToColors();

        cam = GetComponent<Camera>();

        FinishLineReached.OnFinishLineReached += ChangeColor;
    }

    private void ChangeColor(FinishLineReached sender)
    {
        var _randomColorindex = Random.Range(1, colorList.Count + 1);

        while (_randomColorindex == currentRanomIndex) _randomColorindex = Random.Range(1, colorList.Count + 1);

        currentRanomIndex = _randomColorindex;

        cam.DOColor(colorDicitonary[_randomColorindex], transitionTime);
    }

    private void AssignIntToColors()
    {
        for (var i = 0; i < colorList.Count; i++) colorDicitonary.Add(colorList[i].index, colorList[i].color);
    }

    [Serializable]
    public class BackgroundColor
    {
        public Color color;
        public int index;
    }

    private void OnDestroy()
    {
        FinishLineReached.OnFinishLineReached -= ChangeColor;
    }
}