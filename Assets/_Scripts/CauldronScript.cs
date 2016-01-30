using UnityEngine;
using System.Collections;

public class CauldronScript : MonoBehaviour {

	// Use this for initialization

    public int winAmount;
    public int currentAmount;


	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	if(currentAmount >= winAmount)
    {
        Debug.Log("Wonnered");
        //go winscreen
    }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            Destroy(other.gameObject);
            currentAmount++;
        }
    }
}
