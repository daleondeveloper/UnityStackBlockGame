using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroStackController : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] GameObject platformPreFab;
    [SerializeField] Animator playerAnimator;
    [SerializeField] FloatingText floatingText;
    public List<GameObject> blockList = new List<GameObject>();
    private GameObject lastBlockObject;
    private float lastPralformPosZ = 0f;
    private float lastZPosWallTouch = 0f;

    void Start()
    {
        UpdateLastBlockObject();
        for(int i = 0; i < 6; i++)
        {
            createNewPlatform();
        }

    }

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.tag == "wall" )
        {
            if (other.transform.position.z != lastZPosWallTouch)
            {
                createNewPlatform();
            }
            GameObject.FindAnyObjectByType<ShakeScreen>().StartShake();
            lastZPosWallTouch = other.transform.position.z;
        }
    }
    public void IncreaseBlockStack(GameObject _gameObject)
    {
        if (blockList.Contains(_gameObject)) return;
        if(blockList.Count == 6)
        {
            DecreaseBlock(blockList[blockList.Count - 1]);
        }
        transform.position = new Vector3(transform.position.x, transform.position.y + 1f, transform.position.z);
        _gameObject.transform.position = new Vector3(lastBlockObject.transform.position.x,
            lastBlockObject.transform.position.y - 1f, lastBlockObject.transform.position.z);
        _gameObject.transform.SetParent(transform);
        blockList.Add(_gameObject);
        UpdateLastBlockObject();
        playerAnimator.SetTrigger("Jump");
        floatingText.ShowFloatingText(gameObject.transform.position);
    }

    public void DecreaseBlock(GameObject _gameObject)
    {
        _gameObject.transform.parent = null;
        blockList.Remove(_gameObject);
        UpdateLastBlockObject();
    }

    public void createNewPlatform()
    {
       
        GameObject createdCube = Instantiate(platformPreFab, new Vector3(0, 0, 0), Quaternion.identity);
        createdCube.GetComponent<PlatformController>().inializePlatform(lastPralformPosZ + 38f, blockList.Count);
        lastPralformPosZ += 38f;
       
    }
    private void UpdateLastBlockObject()
    {
        if (blockList.Count == 0)
        {
            gameOverScreen.SetActive(true);
            GameObject.FindAnyObjectByType<HeroMovementController>().enabled = false;
        }
        else
        {
            lastBlockObject = blockList[blockList.Count - 1];
        }
    }

}
