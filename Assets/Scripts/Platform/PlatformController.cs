using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    [SerializeField] GameObject cube;
    [SerializeField] GameObject wall;

    [SerializeField] float moveSpeed = 10;
    [SerializeField] float fieldYPos = -11f;
    private bool isMove = true;

  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isMove)
        {
            Vector3 newPosition = transform.position;
            newPosition.y += moveSpeed * Time.deltaTime;
            if(newPosition.y > fieldYPos)
            {
                newPosition.y = fieldYPos;
                isMove = false;
            }
            transform.position = newPosition;
           
        }
    }

    public void inializePlatform(float positionZ,int currentPlayerBlockCount)
    {
        transform.position = new Vector3(13.43723f, -100f, positionZ);

        //CreateCubes
        int newCubeCount = Random.Range(3, 5);
        for (int i = 1; i < newCubeCount; i++)
        {
            GameObject createdCube = Instantiate(cube, new Vector3(0, 0, 0), Quaternion.identity);
            createdCube.transform.position = new Vector3(Random.Range(-2f, 2f), -110f,
                positionZ + 10f + (20f/newCubeCount) * i - 16f);
            createdCube.transform.SetParent(gameObject.transform);

        }

        //CreateWall
        for(int x = -2; x <= 2; x++)
        {
            int wallHeight = Mathf.Clamp(
                Random.Range(1, 6),
                1, currentPlayerBlockCount + newCubeCount);

            for(int y = 0; y < wallHeight; y++)
            {
                GameObject createdWall = Instantiate(wall, new Vector3(0, 0, 0), Quaternion.identity);
                createdWall.transform.position = new Vector3(x, -110f  + y,
                    positionZ + 32f - 16f);
                createdWall.transform.SetParent(gameObject.transform);
            }

        }
    }
}
