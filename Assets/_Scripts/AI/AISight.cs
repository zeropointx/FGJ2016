using UnityEngine;
using System.Collections;

public class AISight : MonoBehaviour {
    Transform player;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
     void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            Ray ray = new Ray(transform.position,player.position - transform.position);
            RaycastHit rayHit;
            float maxRange = 20.0f;
            if(Physics.Raycast(ray, out rayHit, maxRange))
            {
                if(rayHit.transform.tag == "Player")
                {
                    rayHit.transform.GetComponent<PlayerStealth>().LoseGame();
                }
            }
           
        }
    }
}
