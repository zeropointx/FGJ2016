using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerStealth : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void LoseGame()
    {
        Debug.Log("You lostered!");
        SceneManager.LoadScene("LosingScene");
    }
}
