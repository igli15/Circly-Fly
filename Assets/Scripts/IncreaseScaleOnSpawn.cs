using DG.Tweening;
using UnityEngine;

public class IncreaseScaleOnSpawn : MonoBehaviour
{
    private Vector3 initLocalScale;

    [SerializeField] private float scaleTime = 0.2f;

    // Use this for initialization
    private void Start()
    {
        transform.localScale += new Vector3(Random.Range(0, 0.05f), Random.Range(0, 0.08f), Random.Range(0, 0.05f));
        initLocalScale = transform.localScale;

        FinishLineReached.OnFinishLineReached += IncreaseScale;

        IncreaseScale();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void IncreaseScale(FinishLineReached sender = null)
    {
       
        transform.localScale = Vector3.zero;
        transform.DOScale(initLocalScale, scaleTime);
    }

    private void OnDestroy()
    {
        FinishLineReached.OnFinishLineReached -= IncreaseScale;
    }
}