
using UnityEngine;

public class HeroInputController : MonoBehaviour
{
    private float horizontalValue;
    private float currentHorizontalVelocity = 0.0f;
    private float smoothTime = 0.1f;
    private float touchSensitivity = 0.05f;
    public float HorizontalValue
    {
        get { return horizontalValue; }
    }

    void Update()
    {
        HandleHeroHorizontalInput();
    }

    private void HandleHeroHorizontalInput()
    {
        if (Application.platform == RuntimePlatform.Android || Application.platform == RuntimePlatform.IPhonePlayer)
        {
            if (Input.touchCount > 0)
            {
                
                float targetHorizontalValue = Input.GetTouch(0).deltaPosition.x * touchSensitivity;
                horizontalValue = Mathf.SmoothDamp(horizontalValue, targetHorizontalValue, ref currentHorizontalVelocity, smoothTime);
            }
            else
            {
                horizontalValue = 0;
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                float targetHorizontalValue = Input.GetAxis("Mouse X");
                horizontalValue = Mathf.SmoothDamp(horizontalValue, targetHorizontalValue, ref currentHorizontalVelocity, smoothTime);
            }
            else
            {
                horizontalValue = 0;
            }
        }

    }
}
