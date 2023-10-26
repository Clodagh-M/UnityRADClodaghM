using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeControlScript : MonoBehaviour
{

    SphereControl player;
    Animator snakeAnimator;
    enum SnakeState { Idle, Attack, Follow }
    SnakeState currentlyIs = SnakeState.Idle;
    private float aggroRadius = 10;
    private float walkingSpeed = 10;
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


                break;

                case SnakeState.Follow:
                    transform.LookAt(player.transform.position);
                    transform.position += transform.forward * walkingSpeed * Time.deltaTime;

                if (Vector3.Distance(player.transform.position, transform.position) < meleeDistance)
                {
                    currentlyIs = SnakeState.Attack;
                }
                    break;

        }
    }
}
