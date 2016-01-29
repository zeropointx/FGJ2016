﻿using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
    NavMeshAgent navAgent = null;
    public Transform targets;
    public float waitTimer = 0.0f;
    float minWaitTimerDelay = 1.0f;
    float maxWaitTimerDelay = 10.0f;
    public float waitTimerDelay = 0.0f;
	// Use this for initialization
    public enum State
    {
        WALKING,
        WAITING
    }
    public State currentState = State.WALKING;
	void Start () {
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.destination = getRandomTargetPos();
	}
	
	// Update is called once per frame
	void Update () {
        switch(currentState)
        {
            case State.WALKING:
                {
                    if (Vector3.Distance(transform.position, navAgent.destination) < 2.0f)
                    {
                        currentState = State.WAITING;
                        waitTimer = 0.0f;
                        waitTimerDelay = Random.Range(minWaitTimerDelay, maxWaitTimerDelay);
                    }
                    break;
                }
            case State.WAITING:
                {
                    waitTimer += Time.deltaTime;
                    if(waitTimer >= waitTimerDelay)
                    {
                        currentState = State.WALKING;
                        navAgent.destination = getRandomTargetPos();
                    }
                    break;
                }
        }

	}
    Vector3 getRandomTargetPos()
    {
        int randomIndex = Random.Range(0,targets.childCount);
        return targets.GetChild(randomIndex).position;
    }
}