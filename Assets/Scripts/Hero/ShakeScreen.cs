using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeScreen : MonoBehaviour
{
    private Vector3 originalPosition;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        if (shakeDuration > 0)
        {
            transform.position = originalPosition + Random.insideUnitSphere * shakeMagnitude;

            shakeDuration -= Time.deltaTime;
        }
        else
        {
            shakeDuration = 0f;
            transform.position = originalPosition;
        }
    }

    public void StartShake()
    {
        shakeDuration = 0.5f; 
    }
}
