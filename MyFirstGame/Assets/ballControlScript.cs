using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ballControlScript : MonoBehaviour
{   
    Rigidbody rb;
    float kickStrength = 10;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
       
       
    }

    public void KickBall(Transform kicker)
    {
        rb.AddExplosionForce(kickStrength, kicker.position, 4);
        rb.AddForce(kickStrength * kicker.forward, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Plane") {
        print("Boing"); }
        else 
        { 
            snakeControlScript testIfSnake = collision.gameObject.GetComponent<snakeControlScript>();
            if (testIfSnake != null)
            {
                testIfSnake.dieNow();

            }
            print("Ouch");

            KickBall(collision.transform);
        }
    }
}
    