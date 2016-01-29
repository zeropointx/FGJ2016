using UnityEngine;
using System.Collections;

public class PlayerInput : MonoBehaviour 
{
    public float walkSpeed;
    public float backStepSpeed;

    private Vector3 mousePos = new Vector3(255, 255, 255);
    private float mouseSens = 0.25f;

	// Use this for initialization
	void Start () 
    {
        walkSpeed = 5.0f;
        backStepSpeed = 2.0f;
	}
	
	// Update is called once per frame
	void Update () 
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        mousePos = Input.mousePosition - mousePos;
        mousePos = new Vector3(-mousePos.y * mouseSens, mousePos.x * mouseSens, 0);
        mousePos = new Vector3(transform.eulerAngles.x + mousePos.x, transform.eulerAngles.y + mousePos.y, 0);
        transform.eulerAngles = mousePos;
        mousePos = Input.mousePosition;
        
        if (Mathf.Abs(x) > 0)
        {
            Vector3 movement = transform.right;
            movement *= x * walkSpeed;
            transform.position += movement * Time.deltaTime;
        }
        if (Mathf.Abs(y) > 0)
        {
            Vector3 movement = transform.forward;
            movement *= y;
            y *= y > 0 ? walkSpeed : backStepSpeed;  
            transform.position += movement * Time.deltaTime;
        }
        transform.position = new Vector3(transform.position.x, 4, transform.position.z);
	}
}
