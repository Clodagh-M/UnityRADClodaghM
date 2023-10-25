using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeControlScript : MonoBehaviour {

    SphereControl player;
    Animator snakeAnimator;
    enum SnakeState { Idle, Attack, Follow}
    SnakeState currentlyIs = SnakeState.Idle;
    private float aggroRadius = 10;
    private float walkingSpeed = 10;

    // Start is called before the first frame update
    void Start()
    {
        snakeAnimator = GetComponent<Animator>(); 
        player = FindObjectOfType<SphereControl>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentlyIs) {

            case SnakeState.Idle:

                if (Vector3.Distance(player.transform.position) < aggroRadius)
                {
                    currentlyIs = SnakeState.Follow;
                    snakeAnimator.SetBool("isWalking", false);

                    break;

                }
                break;


            case SnakeState.Attack:


                break;

            case SnakeState.Follow:
                {
                    transform.LookAt(player.transform.position);
                    transform.position += transform.forward * walkingSpeed * Time.deltaTime;
                }
                break;
        }

        if (Input.GetKey(KeyCode.Space))
            snakeAnimator.SetBool("isWalking", true);
        else
            snakeAnimator.SetBool("isWalking", false);
    }
    }

