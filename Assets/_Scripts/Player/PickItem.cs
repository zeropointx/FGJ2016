using UnityEngine;
using System.Collections;

public class PickItem : MonoBehaviour 
{

    private GameObject heldItem = null;

	// Use this for initialization
	void Start () 
    {
        heldItem = null;
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldItem == null)
            {
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.DrawRay(hit.point, hit.normal, Color.red, 5.0f);
                    if (hit.transform.gameObject.tag == "PickUp")
                    {
                        heldItem = hit.transform.gameObject;
                        PickObject();
                        Debug.Log("picked up");
                    }
                }
            }
            else
                DropObject();
        }
    }

    private void PickObject()
    {
        heldItem.transform.parent = this.transform;
        heldItem.transform.position += transform.forward * 0.5f + transform.up * 1.25f;
        heldItem.GetComponent<Rigidbody>().isKinematic = true;
    }


    private void DropObject()
    {
        heldItem.transform.parent = null;
        heldItem.GetComponent<Rigidbody>().isKinematic = false;
        heldItem = null;
    }
}
