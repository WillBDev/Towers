using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreenScript : MonoBehaviour {

    public GameObject deathScreen;
    private void Start()
    {
        deathScreen = GameObject.Find("Death Screen");
        gameObject.SetActive(false);
    }

    public void Respawn()
    {
        GetComponent<Canvas>().enabled = false;
    }

    public void MainMenu()
    {
        GetComponent<Canvas>().enabled = true;
        GameObject.Find("Main Menu").GetComponent<Canvas>().enabled = true;
    }
}
