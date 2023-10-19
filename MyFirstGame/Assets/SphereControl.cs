using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.position += (new Vector3(0, 1, 0)) * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.DownArrow))
        { 
            transform.position -= (new Vector3(0, 1, 0)) * Time.deltaTime;
        }

        if (Input.GetKey (KeyCode.LeftArrow))
        {
            transform.position -= transform.right * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.position += transform.right * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.Period))
        {
            transform.position += transform.forward * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, 180 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.down, 180 * Time.deltaTime);
        }

    }
}
