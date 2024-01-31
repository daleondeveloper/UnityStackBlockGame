using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovementController : MonoBehaviour
{
    [SerializeField] private HeroInputController heroInputController;


    [SerializeField] private float forwardMovemenetSpeed;
    [SerializeField] private float horizontalMovementSpeed;
    [SerializeField] private float horizontalLimitValue;


    private float newPositionX;

    void FixedUpdate()
    {
        SetHeroForwardMovement();
        SetHeroHorizontalMovement();
    }

    private void SetHeroForwardMovement()
    {
        transform.Translate(Vector3.forward * forwardMovemenetSpeed * Time.fixedDeltaTime, Space.World);
    }

    private void SetHeroHorizontalMovement()
    {
        float horizontalInput = heroInputController.HorizontalValue;
        float horizontalMovement = horizontalInput * horizontalMovementSpeed * Time.fixedDeltaTime;

        float newPositionX = Mathf.Clamp(transform.position.x + horizontalMovement, -horizontalLimitValue, horizontalLimitValue);
        float newPositionY = transform.position.y;
        float newPositionZ = transform.position.z;

        transform.position = new Vector3(newPositionX, newPositionY, newPositionZ);
    }
}
