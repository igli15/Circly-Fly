using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

public class BackgroundColorChanger : MonoBehaviour
{
    private Camera camera;

    private readonly Dictionary<int, Color> colorDicitonary = new Dictionary<int, Color>();

    public List<BackgroundColor> colorList = new List<BackgroundColor>();

    private int currentRanomIndex;

    // Use this for initialization
    private void Start()
    {
        AssignIntToColors();

        camera = GetComponent<Camera>();

        FinishLineReached.OnFinishLineReached += ChangeColor;
    }

    private void ChangeColor(FinishLineReached sender)
    {
        var _randomColorindex = Random.Range(1, colorList.Count + 1);

        while (_randomColorindex == currentRanomIndex) _randomColorindex = Random.Range(1, colorList.Count + 1);

        currentRanomIndex = _randomColorindex;

        camera.DOColor(colorDicitonary[_randomColorindex], 1f);
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
}