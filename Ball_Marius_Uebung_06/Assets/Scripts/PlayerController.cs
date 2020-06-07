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

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            agent.SetDestination(transform.position);
            animator.SetTrigger("attack");
            UnityEngine.Debug.Log("attack");
        }
        else// if (isMoving && waitFor > 0) {
            //  waitFor--;
            //}else 
        if (transform.position.x == destination.x && transform.position.z == destination.z)
        {
            //isMoving = false;
            animator.SetTrigger("idle");
            UnityEngine.Debug.Log("idle");
        }
        else {
            animator.SetTrigger("run");
        }
        /*UnityEngine.Debug.Log("xt " + transform.position.x);
        UnityEngine.Debug.Log("xd" + destination.x);
        UnityEngine.Debug.Log("yt"  + transform.position.y);
        UnityEngine.Debug.Log("yd" + destination.y);
        UnityEngine.Debug.Log("zt" + transform.position.z);
        UnityEngine.Debug.Log("zd" + destination.z);*/
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
