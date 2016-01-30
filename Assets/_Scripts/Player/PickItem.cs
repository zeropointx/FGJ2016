using UnityEngine;
using System.Collections;

public class PickItem : MonoBehaviour 
{

    private GameObject heldItem;
    private GameObject myCamera = null;
    private float maxGrabDistance;
    private float holdDistance;
    private float throwForce;

	// Use this for initialization
	void Start () 
    {
        heldItem = null;
        myCamera = transform.FindChild("FirstPersonCharacter").GetComponent<Camera>().gameObject;
        maxGrabDistance = 5.0f;
        holdDistance = 2.25f;
        throwForce = 10.0f;
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
                    if (hit.transform.parent.tag == "PickUp")
                    {
                        if (hit.distance < maxGrabDistance)
                        {
                            heldItem = hit.transform.gameObject;
                            Debug.Log(heldItem.name);   
                            PickObject();
                        }
                        else
                            Debug.Log("too far to grab!");
                    }
                }
            }
        }
        else
        {
            UpdateHeldItem();
            if (Input.GetMouseButtonDown(0))
                DropObject(1.0f);
        }
    }

    private void PickObject()
    {
        heldItem.transform.parent.parent = this.transform;
        heldItem.transform.position = transform.position + transform.forward * holdDistance;
        Rigidbody body = heldItem.transform.GetComponent<Rigidbody>();
        body.useGravity = false;
        body.velocity = new Vector3(0, 0, 0);
        body.angularVelocity = new Vector3(0, 0, 0);
    }


    private void DropObject(float throwMultiplier = 0.0f)
    {
        heldItem.transform.parent.parent = null;
        Rigidbody body = heldItem.transform.GetComponent<Rigidbody>();
        body.useGravity = true;
        body.AddForce(throwMultiplier * throwForce * myCamera.transform.forward, ForceMode.Impulse);
        body.AddRelativeTorque(throwMultiplier * new Vector3(-25, 0, 0));
        body.isKinematic = false;
        heldItem = null;
    }

    private void UpdateHeldItem()
    {
        float x = myCamera.transform.eulerAngles.x; 
        if (x > 270 || x < 25)
        {
            Vector3 target = transform.position + transform.up * 0.75f + myCamera.transform.forward * holdDistance;
            heldItem.transform.position = Vector3.LerpUnclamped(heldItem.transform.position, target, 4.0f * Time.deltaTime);

            if (Vector3.Distance(heldItem.transform.position, transform.position) > holdDistance * 1.5f)
            {
                DropObject();
            }
        }
    }
}
