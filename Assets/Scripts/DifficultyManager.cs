using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyManager : MonoBehaviour {

    Score score;
    LineSpawn spawn;
    LineScript line;

    public Material difficulty1;
    public Material difficulty2;
    public Material difficulty3;
    public Material difficulty4;

    public float trueRate;

    // Use this for initialization
    void Start ()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        spawn = GameObject.FindGameObjectWithTag("Spawner").GetComponent<LineSpawn>();
        line = ((GameObject)Resources.Load("Line")).GetComponent<LineScript>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        //Set the firerate over time
        trueRate = 1 - ((score.caught * 2) / 100);
        spawn.fireRate = trueRate;

        //Set the linespeed
        line.speed = 0.1f + (score.caught / 100f);

        //Set the bg color based on the score
        if (score.caught == 10)
        {
            //DarkBlue
            RenderSettings.skybox = difficulty2;
        }
        if (score.caught == 20)
        {
            //Purple
            RenderSettings.skybox = difficulty3;
        }
        if (score.caught == 30)
        {
            //Yellow
            RenderSettings.skybox = difficulty4;
        }
    }

    public void Reset()
    {
        RenderSettings.skybox = difficulty1;
    }
}
