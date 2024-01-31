using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroTrailController : MonoBehaviour
{
    [SerializeField] public GameObject player;  // Гравець, за яким слід буде слідувати
    [SerializeField] public TrailRenderer trailRenderer;

    void Update()
    {
        Vector3 playerPosition = player.transform.position;
        Vector3 trailPosition = Vector3.ProjectOnPlane(playerPosition, Vector3.down);
        trailPosition.y = 0.05f;
        trailRenderer.transform.position = trailPosition;
    }
}