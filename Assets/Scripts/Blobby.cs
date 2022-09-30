using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Blobby : Enemy
{
    public Transform player;
    //public Animator anim;

    public float speed;

    public bool inAir;

    Rigidbody rb;

    Vector3 velocity = Vector3.zero;

    public Enemy enemyScript;

    NavMeshAgent navAgent;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        navAgent = GetComponent<NavMeshAgent>();

        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        //if near player, go towards player
        //play jump animation
        //only in air can move
        //when near player, perform attack

        anim.SetFloat("distance", Vector3.Distance(transform.position, player.position));

        if (Vector3.Distance(transform.position, player.position) < 5)
        {
            //Get ready to do damage jump
            if(!anim.GetBool("jumped"))
            {
                anim.SetBool("canJump", true);
            }
        }
        else
        {
            if (!anim.GetBool("jumped"))
            {
                //Get ready and jump
                anim.SetBool("canJump", true);
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
                {
                    //Move towards player
                    Vector3 dir = player.position - transform.position;
                    //transform.position += dir.normalized * Time.deltaTime * speed;
                    rb.MovePosition(transform.position + dir.normalized * Time.deltaTime * speed);
                }
            }
        }
    }
}
