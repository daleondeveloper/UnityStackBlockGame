using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartButtonAction : MonoBehaviour,IPointerDownHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        GameObject.FindAnyObjectByType<HeroMovementController>().enabled = true;
        Destroy(gameObject);
    }

}
