using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Recipe : MonoBehaviour {
    List<Item> cultistItems = new List<Item>();
	// Use this for initialization
	void Start () {
        GenerateCultistItems();
	}
    void GenerateCultistItems()
    {
        for(int i = 0; i < 20; i++)
        {
            Item tempItem = (Item)Random.Range(0,(int)Item.ITEM20);
            while(!CultistItemContains(tempItem))
            {
                tempItem = (Item)Random.Range(0, (int)Item.ITEM20);
            }
            cultistItems.Add(tempItem);
        }
    }
    bool CultistItemContains(Item item)
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
