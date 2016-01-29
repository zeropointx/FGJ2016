using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AIDirector : MonoBehaviour {
    public GameObject aiPrefab;
    int aiSpawnCount = 5;
    GameObject targets;
    Recipes recipes;
    List<GameObject> ais = new List<GameObject>();
	// Use this for initialization
	void Start () {
        targets = GameObject.Find("Targets");
        recipes = GetComponent<Recipes>();
        SpawnEnemies();
        SetItems();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void SpawnEnemies()
    {
        for(int i = 0; i < aiSpawnCount;i++)
        {
            GameObject g = (GameObject)GameObject.Instantiate(aiPrefab, targets.transform.GetChild(i).position, new Quaternion());
            ais.Add(g);
        }
    }
    void SetItems()
    {
        for(int i = 0; i < ais.Count; i++)
        {
            Ingredient.Type[] items =new Ingredient.Type[] { Ingredient.Type.A, Ingredient.Type.B };
            var hermanni = recipes.GetCultistItems();
            items[0] = hermanni[i*2];
            items[1] = hermanni[i*2 +1];

            ais[i].GetComponent<AI>().setItems(items);
        }
    }
}
