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
    public GameObject treeRoot;
    public GameObject lizard;
    public GameObject teddy;
    public GameObject nokia;
    public GameObject bat;
    public GameObject bottleRed;
    public GameObject bottleGreen;
    public GameObject bottleBlue;
    public GameObject scorpion;
    public GameObject diamond;
    public GameObject salt;
    public GameObject gamePad;
    public GameObject eggThing;
    public GameObject toothBrush;

    public enum Type
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T
    };

    private Type type = Type.A;
    public bool isBeingPickedUp = false;
    void Awake()
    {
 
    }
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
                newModel = Instantiate(sibs);
                break;
            case Type.F:
                newModel = Instantiate(treeRoot);
                break;
            case Type.G:
                newModel = Instantiate(lizard);
                break;
            case Type.H:
                newModel = Instantiate(teddy);
                break;
            case Type.I:
                newModel = Instantiate(nokia);
                break;
            case Type.J:
                newModel = Instantiate(bat);
                break;
            case Type.K:
                newModel = Instantiate(bottleRed);
                break;
            case Type.M:
                newModel = Instantiate(bottleGreen);
                break;
            case Type.N:
                newModel = Instantiate(bottleBlue);
                break;
            case Type.O:
                newModel = Instantiate(scorpion);
                break;
            case Type.P:
                newModel = Instantiate(diamond);
                break;
            case Type.Q:
                newModel = Instantiate(salt);
                break;
            case Type.R:
                newModel = Instantiate(gamePad);
                break;
            case Type.S:
                newModel = Instantiate(eggThing);
                break; 
            case Type.T:
                newModel = Instantiate(toothBrush);
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
