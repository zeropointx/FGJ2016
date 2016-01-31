﻿using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class CauldronScript : MonoBehaviour {

	// Use this for initialization

    public int winAmount;
    public int currentAmount;
    public AudioSource splashAudio;


	void Start () 
    {
	
	}
	
	// Update is called once per frame
	void Update () 
    {
	if(currentAmount >= winAmount)
    {
        Debug.Log("Wonnered");
        SceneManager.LoadScene("VictoryScene");
    }
	}

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickUp")
        {
            splashAudio.Play();
            Destroy(other.transform.parent.gameObject);
            currentAmount++;
        }
    }
}
