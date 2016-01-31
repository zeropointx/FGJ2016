using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpawnIngredients : MonoBehaviour {

    public GameObject pickUp;

	// Use this for initialization
	void Start () 
    {
        int children = transform.childCount;
        List<Ingredient.Type> types = GameObject.Find("/AiManager").GetComponent<Recipes>().GetPlayerItems();
        for (int i = 0; i < types.Count; i++)
        {
            GameObject hub = transform.GetChild((Random.Range(0, children - 1))).gameObject;
            int hubChilds = hub.transform.childCount;
            GameObject point = hub.transform.GetChild(Random.Range(0, hubChilds - 1)).gameObject;
            GameObject spawn = Instantiate(pickUp);
            spawn.transform.position = point.transform.position;
            spawn.GetComponent<Ingredient>().SetType(types[i]);
            if (hubChilds <= 4)
            {
                children--;
                DestroyImmediate(hub);
            }
            else
                DestroyImmediate(point);
        }
	}

    // Update is called once per frame
    void Update() 
    {
	
	}
}
