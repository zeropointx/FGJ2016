using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HUD : MonoBehaviour {

    GameObject text;
    GameObject cauldron;
    CauldronScript cauldronScript;
	// Use this for initialization
	void Start () 
    {
        text = GameObject.Find("ItemsLeft");
        cauldron = GameObject.Find("Pata");
        cauldronScript = cauldron.GetComponent<CauldronScript>();
	}
	
	// Update is called once per frame
	void Update () 
    {
	text.GetComponent<Text>().text = "Items placed: " + cauldronScript.currentAmount + " / " + cauldronScript.winAmount;
	}
}
