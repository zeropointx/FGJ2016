using UnityEngine;
using System.Collections;

public class PickItem : MonoBehaviour 
{

    private GameObject heldItem;
    private float maxGrabDistance;
    private Vector2 holdDistance;
    private float throwForce;

	// Use this for initialization
	void Start () 
    {
        heldItem = null;
        maxGrabDistance = 5.0f;
        holdDistance = new Vector2(2.5f, 0.75f);
        throwForce = 7.5f;
	}

    // Update is called once per frame
    void Update()
    {
        if (heldItem == null)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0.5f));
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit))
                {
                    Debug.DrawRay(hit.point, hit.normal, Color.red, 5.0f);
                    if (hit.transform.gameObject.tag == "PickUp")
                    {
                        if (hit.distance < maxGrabDistance)
                        {
                            heldItem = hit.transform.gameObject;
                            PickObject();
                            Debug.Log("picked up");
                        }
                        else
                            Debug.Log("too far to grab!");
                    }
                }
            }
        }
        else
        {
            if (Input.GetMouseButtonDown(0))
                DropObject();
        }
    }

    private void PickObject()
    {
        heldItem.transform.parent = this.transform;
        heldItem.transform.position = transform.position + transform.forward * holdDistance.x + transform.up * holdDistance.y;
        heldItem.GetComponent<Rigidbody>().isKinematic = true;
    }


    private void DropObject()
    {
        heldItem.transform.parent = null;
        Rigidbody body = heldItem.GetComponent<Rigidbody>();
        body.isKinematic = false;
        body.AddForce(throwForce * transform.forward + throwForce * 0.5f * transform.up, ForceMode.Impulse);
        body.AddForceAtPosition(0.1f * throwForce * transform.forward, new Vector3(0, 0, 1), ForceMode.Impulse);
        heldItem = null;
    }
}
