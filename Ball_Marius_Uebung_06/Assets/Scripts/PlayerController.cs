using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    UnityEngine.AI.NavMeshAgent agent;
    Animator animator;
    RaycastHit ray;
    Vector3 destination;
    bool isMoving;
    int waitFor = 2;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();
        destination = transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            isMoving = false;
            animator.ResetTrigger("run");
            agent.SetDestination(transform.position);
            animator.SetTrigger("attack");
            UnityEngine.Debug.Log("attack");
        }
        else// if (isMoving && waitFor > 0) {
            //  waitFor--;
            //}else 
        if (transform.position.x == destination.x && transform.position.z == destination.z)
        {
            isMoving = false;
            animator.SetTrigger("idle");
            UnityEngine.Debug.Log("idle");
        }
        else {
            if(isMoving)
            animator.SetTrigger("run");
        }
        
    }

    public void Move(RaycastHit raycast) {
        isMoving = true;
        animator.SetTrigger("run");
        animator.SetTrigger("run");
        UnityEngine.Debug.Log("start");
        destination = raycast.point;
        agent.SetDestination(raycast.point);
        UnityEngine.Debug.Log("end");
    }
}
