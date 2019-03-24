using System;
using UnityEngine;

public class FinishLineReached : MonoBehaviour
{
    public static Action<FinishLineReached> OnFinishLineReached;

    [SerializeField] private GameObject finishLine;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform == finishLine.transform)
            if (OnFinishLineReached != null)
                OnFinishLineReached(this);
    }
}