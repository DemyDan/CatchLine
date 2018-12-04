using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineSpawn : MonoBehaviour {

    GameObject[] spawnPoints;
    GameObject currentPoint;
    public Rigidbody projectile;
    int index;

    public float fireRate = 1F;
    private float nextFire = 0.0F;
    private int lastShootPoint;

    void Start()
    {
        spawnPoints = GameObject.FindGameObjectsWithTag("Spawn");

    }

    void Update()
    {
        if (Time.time > nextFire)
        {
            //Choose a random spawnpoint
            //Ensure it doesnt shoot 2 times at the same point
            if(index == lastShootPoint)
            {
                index = Random.Range(0, spawnPoints.Length);
            }
            currentPoint = spawnPoints[index];
            //Make it shoot
            Rigidbody line = Instantiate(projectile, currentPoint.transform.position, currentPoint.transform.rotation);
            Color col = new Color(Random.value, Random.value, Random.value, 1.0f);
            line.GetComponent<MeshRenderer>().material.color = col;

            nextFire = Time.time + fireRate;
            lastShootPoint = index;
            Debug.Log(lastShootPoint);
        }
    }
}
