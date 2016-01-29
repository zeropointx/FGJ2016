using UnityEngine;
using System.Collections;

public class AI : MonoBehaviour {
    NavMeshAgent navAgent = null;
    Transform targets;
    public float waitTimer = 0.0f;
    float minWaitTimerDelay = 3.0f;
    float maxWaitTimerDelay = 10.0f;
    public float waitTimerDelay = 0.0f;
    public Ingredient.Type[] items = new Ingredient.Type[] { Ingredient.Type.A, Ingredient.Type.B };
    public void setItems(Ingredient.Type[] items)
    {
        this.items = items;
    }
	// Use this for initialization
    public enum State
    {
        WALKING,
        WAITING
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
        }

	}
    Vector3 getRandomTargetPos()
    {
        int randomIndex = Random.Range(0,targets.childCount);
        return targets.GetChild(randomIndex).position;
    }
}
