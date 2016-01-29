using UnityEngine;
using System.Collections;

public class PickItem : MonoBehaviour 
{

	// Use this for initialization
	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Debug.DrawRay(hit.point, hit.normal, Color.red, 5.0f);
                if (hit.transform.gameObject.tag == "PickUp")
                    Debug.Log("picked up");
            }
        }

	}
}
