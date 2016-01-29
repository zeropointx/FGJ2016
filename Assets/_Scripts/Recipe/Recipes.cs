using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Recipes : MonoBehaviour {
    List<Ingredient.Type> cultistItems = new List<Ingredient.Type>();
    List<Ingredient.Type> playerItems = new List<Ingredient.Type>();
    public List<Ingredient.Type> GetCultistItems()
    {
        return cultistItems;
    }
	// Use this for initialization
	void Start () {
        GenerateCultistItems();
        GeneratePlayerItems();
	}
    void GenerateCultistItems()
    {
        for(int i = 0; i < 10; i++)
        {
            Ingredient.Type tempItem = (Ingredient.Type)Random.Range(0, (int)Ingredient.Type.U);
            while(CultistItemsContains(tempItem))
            {
                tempItem = (Ingredient.Type)Random.Range(0, (int)Ingredient.Type.U);
            }
            cultistItems.Add(tempItem);
        }
    }
    void GeneratePlayerItems()
    {
        for (int i = 0; i < 10; i++)
        {
            Ingredient.Type tempItem = (Ingredient.Type)Random.Range(0, (int)Ingredient.Type.U);
            while (CultistItemsContains(tempItem) || PlayerItemsContains(tempItem))
            {
                tempItem = (Ingredient.Type)Random.Range(0, (int)Ingredient.Type.U);
            }
            playerItems.Add(tempItem);
        }
    }
    bool CultistItemsContains(Ingredient.Type item)
    {
        for(int i = 0; i < cultistItems.Count; i++)
        {
            if (cultistItems[i] == item)
                return true;
        }
        return false;
    }
    bool PlayerItemsContains(Ingredient.Type item)
    {
        for (int i = 0; i < playerItems.Count; i++)
        {
            if (playerItems[i] == item)
                return true;
        }
        return false;
    }
	// Update is called once per frame
	void Update () {
	
	}
}
