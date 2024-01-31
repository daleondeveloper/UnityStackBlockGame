using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{

    [SerializeField] private HeroStackController heroStackController;
    
    private bool isStack = false;
    

    void Start()
    {
        heroStackController = GameObject.FindObjectOfType<HeroStackController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if((other.gameObject.tag == "player" || other.gameObject.tag == "cube") && !isStack)
        {
            isStack = true;
            heroStackController.IncreaseBlockStack(gameObject);
            
        }else if(other.gameObject.tag == "wall" && isStack)
        {
            heroStackController.DecreaseBlock(gameObject);
           // heroStackController.createNewPlatform();
        }
    }

}
