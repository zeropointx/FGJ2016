using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ingredient : MonoBehaviour 
{

    public Vector3 startPos;

    public GameObject burger;
    public GameObject pepsi;

    public enum Type
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U
    };

    private Type type = Type.A;
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

        GameObject newModel = null;
        switch(type)
        {
            case Type.A:
            case Type.B:
            case Type.C:
            case Type.D:
            case Type.E:
            case Type.F:
            case Type.G:
            case Type.H:
            case Type.I:
            case Type.J:
                newModel = Instantiate(pepsi);
                break;

            case Type.K:
            case Type.M:
            case Type.N:
            case Type.O:
            case Type.P:
            case Type.Q:
            case Type.R:
            case Type.S:
            case Type.T:
            case Type.U:
                newModel = Instantiate(burger);
                break;

            default:
                Debug.Log("Invalid ingredient type!");
                return;
        }
        GameObject old = transform.GetChild(0).gameObject;
        newModel.transform.position = old.transform.position;
        newModel.transform.rotation = old.transform.rotation;
        DestroyImmediate(old);
        newModel.transform.parent = transform;
    }
}
