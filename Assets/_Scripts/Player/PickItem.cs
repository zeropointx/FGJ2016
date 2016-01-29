using UnityEngine;
using System.Collections;

public class PickItem : MonoBehaviour 
{

    private bool holdingItem;

	// Use this for initialization
	void Start () 
    {
        holdingItem = false;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!holdingItem)
            {
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.DrawRay(hit.point, hit.normal, Color.red, 5.0f);
                    if (hit.transform.gameObject.tag == "PickUp")
                    {
                        //holdingItem = true;
                        //TODO pick physics item
                        Debug.Log("picked up");
                    }
                }
            }
            else
            {
                //TODO throw item
            }
        }
    }
}
