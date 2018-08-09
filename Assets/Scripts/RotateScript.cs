using System;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    
    [SerializeField] [Range(-100, 100)] private float rotationSpeed = 0;

    [SerializeField] private GameObject target;

    // Use this for initialization
    private void Awake()
    {

    }

    // Update is called once per frame
    private void Update()
    {
        transform.RotateAround(target.transform.position, new Vector3(0, 0, 1), -rotationSpeed * Time.deltaTime);
    }

    public void IncreaseRotationSpeed(float increment)
    {
        rotationSpeed += increment;
    }

    public void SetRotationSpeed(float newRotSpeed)
    {
        rotationSpeed = newRotSpeed;
    }

}