using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Recipe : MonoBehaviour {
    List<Ingredient.Type> cultistItems = new List<Ingredient.Type>();
	// Use this for initialization
	void Start () {
        GenerateCultistItems();
	}
    void GenerateCultistItems()
    {
        for(int i = 0; i < 20; i++)
        {
            Ingredient.Type tempItem = (Ingredient.Type)Random.Range(0, (int)Ingredient.Type.U);
            while(!CultistItemContains(tempItem))
            {
                tempItem = (Ingredient.Type)Random.Range(0, (int)Ingredient.Type.U);
            }
            cultistItems.Add(tempItem);
        }
    }
    bool CultistItemContains(Ingredient.Type item)
    {
        for(int i = 0; i < cultistItems.Count; i++)
        {
            if (cultistItems[i] == item)
                return true;
        }
        return false;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
