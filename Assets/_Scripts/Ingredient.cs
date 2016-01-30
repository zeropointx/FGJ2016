using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ingredient : MonoBehaviour 
{

    public Vector3 startPos;

    public GameObject burger;

    public enum Type
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U
    };

    private Type type;
    public bool isBeingPickedUp = false;
    
    // Use this for initialization
	void Start () 
    {
        type = Type.A;
        startPos = transform.position;
	}
	
	// Update is called once per frame
	void Update () 
    {
	    
	}

    public Type GetType()
    {
        return type;
    }

    public void SetType(Type _type)
    {
        type = _type;
        /*
        GameObject old = transform.parent.GetChild(0).gameObject;
        old.SetActive(false);
        GameObject newModel = Instantiate(burger);
        newModel.transform.position = old.transform.position;
        newModel.transform.rotation = old.transform.rotation;
        Destroy(old);
        newModel.transform.parent = transform;
        */
    }
}
