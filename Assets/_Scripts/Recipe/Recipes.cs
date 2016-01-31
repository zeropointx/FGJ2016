using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Recipes : MonoBehaviour {
    List<Ingredient.Type> playerItems = new List<Ingredient.Type>();
    public List<Ingredient.Type> GetPlayerItems()
    {
        return playerItems;
    }
	// Use this for initialization
    void Awake()
    {
        GeneratePlayerItems();
    }
	void Start () {
     
	}
    void GeneratePlayerItems()
    {
        for (int i = 0; i < 10; i++)
        {
            Ingredient.Type tempItem = (Ingredient.Type)Random.Range(0, (int)Ingredient.Type.S);
            while (PlayerItemsContains(tempItem))
            {
                tempItem = (Ingredient.Type)Random.Range(0, (int)Ingredient.Type.S);
            }
            playerItems.Add(tempItem);
        }
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
