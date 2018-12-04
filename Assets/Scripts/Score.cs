using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text linesCaught;
    public Text totalCaught;

    public GameObject game;
    public GameObject deathScreen;
    public GameObject heart1;
    public GameObject heart2;
    public GameObject heart3;

    public int caught;
    public int HP = 1;

    // Use this for initialization
    void Start ()
    {
        caught = 0;
    }

    public void SetGotText()
    {
        caught += 1;
        linesCaught.text = caught.ToString();
    }

    public void SetHearts()
    {
        HP = HP - 1;
        if(HP == 2)
        {
            heart3.SetActive(false);
        }
        if (HP == 1)
        {
            heart2.SetActive(false);
        }
        if (HP == 0)
        {
            Dead();
        }
        Debug.Log("Your HP is: " + HP);
    }

    public void Dead()
    {
        game.SetActive(false);
        linesCaught.text = "";
        totalCaught.text = caught + " lines caught";

        //Disable every line in screen after death
        GameObject[] lines = GameObject.FindGameObjectsWithTag("Line");

        foreach (GameObject line in lines)
        {
            line.SetActive(false);
        }
 
        deathScreen.SetActive(true);
    }
}
