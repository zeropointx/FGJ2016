using UnityEngine;
using System.Collections;

public class SpawnIngredients : MonoBehaviour {

    public GameObject pickUp;
    private const int INGREDIENT_TYPES = 20;
    private const int SPAWN_COUNT = 5;

	// Use this for initialization
	void Start () 
    {
        Debug.Log("spawn start");
        for (int i = 0; i < SPAWN_COUNT; i++)
        {
            Debug.Log("spawn");
            GameObject obj1 = transform.GetChild((Random.Range(0, (int)transform.childCount) - 1)).gameObject;
            GameObject obj2 = pickUp;//(GameObject)Resources.Load("_Prefabs/PickUp");
            obj2.transform.position = obj1.transform.position;
            Destroy(obj1);
            Instantiate(obj2);
        }
	}

    // Update is called once per frame
    void Update() 
    {
	
	}
}
