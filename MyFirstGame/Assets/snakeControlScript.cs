using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeControlScript : MonoBehaviour
{

    SphereControl player;
    Animator snakeAnimator;
    enum SnakeState { Idle, Attack, Follow, Dying }
    SnakeState currentlyIs = SnakeState.Idle;
    private float aggroRadius = 10;
    private float walkingSpeed = 1;
    private float meleeDistance = 1;

    // Start is called before the first frame update
    void Start()
    {
        snakeAnimator = GetComponent<Animator>();
        player = FindObjectOfType<SphereControl>();
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentlyIs)
        {
            case SnakeState.Idle:

                if (Vector3.Distance(player.transform.position, transform.position) < aggroRadius)
                {
                    currentlyIs = SnakeState.Follow;
                    snakeAnimator.SetBool("isWalking", true);
                }
                break; 


            case SnakeState.Attack:

                if (Vector3.Distance(player.transform.position, transform.position) > 2 * meleeDistance)
                {
                    currentlyIs = SnakeState.Follow;
                    snakeAnimator.SetBool("isAttacking", false);
                    snakeAnimator.SetBool((int)SnakeState.Follow, true);
                }


                break;

            case SnakeState.Follow:

                Vector3 target = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
                transform.LookAt(target);
                transform.position += transform.forward * walkingSpeed * Time.deltaTime;

                if (Vector3.Distance(player.transform.position, transform.position) < meleeDistance)
                {
                    currentlyIs = SnakeState.Attack;
                }
                    break;

            case SnakeState.Dying:

                break;
                
        }
            
       

        }

    internal void dieNow()
    {
        snakeAnimator.SetBool("isDying", true);
        Destroy(gameObject,5);
        currentlyIs = SnakeState.Dying;
    }
}
