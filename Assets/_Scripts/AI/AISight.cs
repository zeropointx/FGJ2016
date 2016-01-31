using UnityEngine;
using System.Collections;

public class AISight : MonoBehaviour {
    public Transform head;
    Transform player;
    float startTimer = 0.0f;
    float startDelay = 0.5f;
	// Use this for initialization
	void Start () {
        player = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
        if (startTimer < startDelay)
            startTimer += Time.deltaTime;
	}
     void OnTriggerStay(Collider other) {
         if (startTimer < startDelay)
             return;
        if(other.tag == "Player")
        {
            Ray ray = new Ray(head.position, (player.position - head.position).normalized);
            Debug.DrawLine(head.position,(player.position - head.position).normalized*10.0f,Color.white,2.0f);
            RaycastHit rayHit;
            float maxRange = 10.0f;
            int layer = ~(1 << 8) ;
            if(Physics.Raycast(ray, out rayHit, maxRange, layer ))
            {
                if(rayHit.transform.tag == "Player")
                {
                    rayHit.transform.GetComponent<PlayerStealth>().LoseGame();
                }
            }
        }
        else if(other.tag == "PickUp")
        {
            Ray ray = new Ray(transform.position, other.transform.position - transform.position);
            RaycastHit rayHit;
            float maxRange = 20.0f;
            if (Physics.Raycast(ray, out rayHit, maxRange))
            {
                if (rayHit.transform.tag == "PickUp")
                {
                    if (rayHit.transform.parent == null || rayHit.transform.parent.GetComponent<Ingredient>() == null)
                    {
                        return;
                    }
                    if(Vector3.Distance(rayHit.transform.parent.GetComponent<Ingredient>().startPos, rayHit.transform.position) > 2.0f)
                    {
                        Ingredient ing = rayHit.transform.parent.GetComponent<Ingredient>();
                        if (!rayHit.transform.parent.GetComponent<Ingredient>().isBeingPickedUp)
                            transform.root.GetComponent<AI>().FetchItem(rayHit.transform);
                    }
                   
                }
            }
        }
    }
}
