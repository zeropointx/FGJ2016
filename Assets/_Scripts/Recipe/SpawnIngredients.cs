using UnityEngine;
using System.Collections;

public class SpawnIngredients : MonoBehaviour {

    public GameObject pickUp;
    private const int INGREDIENT_TYPES = 20;
    private const int SPAWN_COUNT = 5;

	// Use this for initialization
	void Start () 
    {
        for (int i = 0; i < SPAWN_COUNT; i++)
        {
            if (transform.childCount <= 0)
                break;
            GameObject point = transform.GetChild((Random.Range(0, (int)transform.childCount) - 1)).gameObject;
            GameObject spawn = pickUp;//(GameObject)Resources.Load("_Prefabs/PickUp");
            spawn.transform.position = point.transform.position;
            Destroy(point);
            Instantiate(spawn);
        }
	}

    // Update is called once per frame
    void Update() 
    {
	
	}
}
