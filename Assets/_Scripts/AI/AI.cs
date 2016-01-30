using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
    NavMeshAgent navAgent = null;
    Transform targets;
    public float waitTimer = 0.0f;
    float minWaitTimerDelay = 3.0f;
    float maxWaitTimerDelay = 10.0f;
    public float waitTimerDelay = 0.0f;
    public Transform targetItem = null;
    float holdItemDistance = 1.0f;
	// Use this for initialization
    public enum State
    {
        WALKING,
        WAITING,
        FETCH_ITEM,
        TAKE_ITEM_BACK
    }
    public State currentState = State.WALKING;
	void Start () {
        targets = GameObject.Find("Targets").transform;
        navAgent = GetComponent<NavMeshAgent>();
        navAgent.SetDestination(getRandomTargetPos());
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
                        navAgent.Stop(true);
                    }
                    break;
                }
            case State.WAITING:
                {
                    waitTimer += Time.deltaTime;
                    if(waitTimer >= waitTimerDelay)
                    {
                        currentState = State.WALKING;
                        navAgent.SetDestination(getRandomTargetPos());
                        navAgent.Resume();

                    }
                    break;
                }
            case State.FETCH_ITEM:
                {
                    if(Vector3.Distance(transform.position, targetItem.position) < 2.0f)
                    {
                        currentState = State.TAKE_ITEM_BACK;
                        navAgent.SetDestination(targetItem.parent.GetComponent<Ingredient>().startPos);
                        PickObject();
                    }
                    else
                    if(navAgent.destination != targetItem.position)
                        navAgent.SetDestination(targetItem.position);
                    break;
                }
            case State.TAKE_ITEM_BACK:
                {
                    if (Vector3.Distance(transform.position, targetItem.position) > 3.0f)
                    {
                        currentState = State.FETCH_ITEM;
                        navAgent.SetDestination(targetItem.position);
                    }
                    if (Vector3.Distance(transform.position, targetItem.parent.GetComponent<Ingredient>().startPos) < 2.0f)
                    {
                        currentState = State.WAITING;
                        waitTimerDelay = Random.Range(minWaitTimerDelay, maxWaitTimerDelay);
                        navAgent.Stop(true);
                        DropObject();
                    }
                    break;
                }

        }


	}
    public void FetchItem(Transform item)
    {
        if (targetItem != null)
            return;

        targetItem = item;
        targetItem.parent.GetComponent<Ingredient>().isBeingPickedUp = true;
        navAgent.SetDestination(targetItem.position);
        navAgent.Resume();
        currentState = State.FETCH_ITEM;
    }
    private void PickObject()
    {
       
        targetItem.root.parent = this.transform;
        targetItem.position = transform.position + transform.forward * holdItemDistance;
        targetItem.GetComponent<Rigidbody>().isKinematic = true;
    }


    private void DropObject()
    {
        targetItem.parent.GetComponent<Ingredient>().isBeingPickedUp = false;
        targetItem.parent.parent = null;
        Rigidbody body = targetItem.GetComponent<Rigidbody>();
        body.isKinematic = false;
        targetItem = null;
    }

    Vector3 getRandomTargetPos()
    {
        int randomIndex = Random.Range(0,targets.childCount);
        return targets.GetChild(randomIndex).position;
    }
}
