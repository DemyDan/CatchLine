using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineScript : MonoBehaviour {

    Rigidbody rb;
    DifficultyManager diff;
    Score score;

    public GameObject center;
    public GameObject Sphere;
    public float speed;

    bool that = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();

        center = GameObject.FindGameObjectWithTag("Center");
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<Score>();
        diff = GameObject.FindGameObjectWithTag("Diff").GetComponent<DifficultyManager>();
        Sphere = GameObject.FindGameObjectWithTag("Finish");
    }
	
	// Update is called once per frame
	void Update ()
    {
        Vector3 dir = center.transform.position - transform.position;

        rb.AddForce(dir * speed);

        //Makes the line look at you
        transform.LookAt(transform.position + new Vector3(0, 0, 1), center.transform.position - transform.position);
    }

    void Caught()
    {
        Destroy(gameObject);
    }

    IEnumerator Shrink()
    {
       // GetComponent<Collider>().isTrigger = true;
        for (int i = 0; i <= 11; i++)
        {
            transform.localScale /= 1.2f;
            transform.position = Vector3.MoveTowards(transform.position, transform.forward, Time.deltaTime);
            yield return new WaitForFixedUpdate();
        }
    }

    void OnCollisionEnter(Collision collider)
    {
        if (collider.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            Debug.Log("Oof");
            score.SetHearts();

            that = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Center") && !that)
        {
            StartCoroutine(Shrink());
            Invoke("Caught", 0.1f);
            Debug.Log("Nice");
            score.SetGotText();
        }
    }
}
