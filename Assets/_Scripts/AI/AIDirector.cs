using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class AIDirector : MonoBehaviour {
    public GameObject aiPrefab;
    int aiSpawnCount = 7;
    GameObject targets;
    Recipes recipes;
    List<GameObject> ais = new List<GameObject>();
	// Use this for initialization
	void Start () {
        targets = GameObject.Find("Targets");
        recipes = GetComponent<Recipes>();
        SpawnEnemies();
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
}
