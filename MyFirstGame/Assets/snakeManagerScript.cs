using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeManagerScript : MonoBehaviour
{
    public Transform snakeCloneTemplate;

    int numberOfSnakes= 150;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < numberOfSnakes; i++)
        {
            Vector3 position = new Vector3(
                Random.Range(60.1f, -58.5f),
                0.026f,
                Random.Range(74.6f, -74.2f));

            Instantiate(snakeCloneTemplate, position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
