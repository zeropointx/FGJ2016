using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ingredient : MonoBehaviour 
{

    public Vector3 startPos;

    public GameObject burger;
    public GameObject pepsi;
    public GameObject axe;
    public GameObject bone;
    public GameObject sibs;

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

    public Ingredient.Type GetIngredientType()
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
                newModel = Instantiate(burger);
                break;
            case Type.B:
                newModel = Instantiate(pepsi);
                break;
            case Type.C:
                newModel = Instantiate(axe);
                break;
            case Type.D:
                newModel = Instantiate(bone);
                break;
            case Type.E:
                break;
            case Type.F:
            case Type.G:
            case Type.H:
            case Type.I:
            case Type.J:
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
                newModel = Instantiate(sibs);
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
