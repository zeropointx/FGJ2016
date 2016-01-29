using UnityEngine;
using System.Collections;

public class Ingredient : MonoBehaviour 
{

    public enum Type
    {
        A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U
    };

    private Type type;

	// Use this for initialization
	void Start () 
    {
        type = Type.A;
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
        //TODO switch model
    }
}
