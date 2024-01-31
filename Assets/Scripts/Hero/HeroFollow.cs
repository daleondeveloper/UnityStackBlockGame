using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroFollow: MonoBehaviour
{

    [SerializeField] private Transform heroTransform;
    private Vector3 offset;
    private Vector3 newPosition;
    [SerializeField] private float lerpValue;
    void Start()
    {
        offset = transform.position - heroTransform.position;
        
    }


    void LateUpdate()
    {
        newPosition = heroTransform.transform.position + offset;
        newPosition.x = transform.position.x;
        newPosition.y = transform.position.y;
        transform.position = newPosition;
        // SetCameraSmoothFollow();
    }

    private void SetCameraSmoothFollow()
    {
        newPosition = Vector3.Lerp(transform.position, 
            new Vector3(0f, heroTransform.position.y, heroTransform.position.z) + offset,
            lerpValue * Time.deltaTime);
        if(newPosition.z < transform.position.z)
        {
            newPosition.z = transform.position.z;
        }
        transform.position = newPosition;
    }
}
