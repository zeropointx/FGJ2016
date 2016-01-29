using UnityEngine;
using System.Collections;

public class AIDirector : MonoBehaviour {
    public GameObject aiPrefab;
    int aiSpawnCount = 5;
    GameObject targets;
	// Use this for initialization
	void Start () {
        targets = GameObject.Find("Targets");
        SpawnEnemies();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void SpawnEnemies()
    {
        for(int i = 0; i < aiSpawnCount;i++)
        {
            GameObject.Instantiate(aiPrefab, targets.transform.GetChild(i).position, new Quaternion());
        }
    }
}
