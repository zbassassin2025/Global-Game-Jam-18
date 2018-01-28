using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script Programmer: Zac Bogner
*/

public class VirusScript : MonoBehaviour
{
    public float virusSpeed = 0;

    public GameObject virus;
    public GameObject player;

    public int bloodCells = 1;

    bool isSpawning = false;
    public float minTime = 3.0f;
    public float maxTime = 5.0f;
    private int cellIndex = 0;
    

    void Awake()
    {
        GameObject.FindGameObjectWithTag("Virus");
    }

    private IEnumerator SpawnObject(int index, float seconds)
    {
        Debug.Log("Waiting for " + seconds + " seconds");

        yield return new WaitForSeconds(seconds);
        Instantiate(virus.gameObject, transform.position, transform.rotation);

        if(Vector3.Distance(transform.position, player.transform.position) > 0)
        {
            GetComponent<Rigidbody>().AddForce(virus.transform.position - transform.position);
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * virusSpeed;
        }

        isSpawning = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            GetComponent<Rigidbody>().AddForce(col.transform.position - transform.position);
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * virusSpeed;
        }
    }

    void OnTriggerStay(Collider col) // chasing
    {
        if (col.tag == "Player")
        {
            GetComponent<Rigidbody>().AddForce(col.transform.position - transform.position);
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * virusSpeed;
        }

        if (col.tag == "Blood")
        {
            GetComponent<Rigidbody>().AddForce(col.transform.position - transform.position);
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * virusSpeed;
        }
    }

        void OnCollisionEnter(Collision col) // destroy
        {
            if (col.transform.tag == "Blood")
            {
                Destroy(col.gameObject);
            }
        }

       void Update()
    {
        if (!isSpawning)
        {
            isSpawning = true;
            int cellIndex = Random.Range(0, 10);
            StartCoroutine(SpawnObject(cellIndex, Random.Range(minTime, maxTime)));
        }
        else if (maxTime > 10)
        {
            isSpawning = false;
            return;
        }

            if (maxTime > 10)
            {
                StartCoroutine(SpawnObject(cellIndex, Random.RandomRange(5, 20)));
            }
        }
    }

