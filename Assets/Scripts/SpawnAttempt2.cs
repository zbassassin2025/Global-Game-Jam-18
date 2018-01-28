using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
 * Script Programmer: Zac Bogner
 * */
public class SpawnAttempt2 : MonoBehaviour
{
    // A simple spawner class 
    public int maxNumberCells = 100;
    public int cellCount = 0;

    bool isSpawning = false;
    public float minTime = 3.0f;
    public float maxTime = 5.0f;
    public GameObject[] redCells = new GameObject[2]; // Array of prefabs
    private int cellIndex = 0;
    private Rigidbody rb;
    public SpawnAttempt2 c;
  

    void Awake()
    {
        GameObject.FindGameObjectWithTag("Blood");
        cellIndex = 10;
        rb = GetComponent<Rigidbody>();
    }

    IEnumerator SpawnObject(int index, float seconds)
    {
        //Debug.Log("Waiting for " + seconds + " seconds");

        yield return new WaitForSeconds(seconds);

        //Instantiate(redCells[0].gameObject, transform.position, transform.rotation);

        isSpawning = false;
    }

    private IEnumerator Cluster()
    {
        if (minTime >= 3 && maxTime >= 5)
        {
            foreach (GameObject c in redCells)
            {
                if (c != null)
                {
                    continue;
                }

                Instantiate(redCells[1].gameObject, transform.position, transform.rotation);
                Instantiate(redCells[2].gameObject, transform.position, transform.rotation);
                Instantiate(redCells[3].gameObject, transform.position, transform.rotation);
            }
            yield return null;
        }
    }

    void Update()
    {
        if (!(cellCount >= maxNumberCells))
        {

            if (!isSpawning)
            {
                isSpawning = true;
                int cellIndex = Random.Range(0, redCells.Length);
                StartCoroutine(Cluster());
                //Debug.Log("Adding " + cellCount);
                cellCount += 3;
                StartCoroutine(SpawnObject(cellIndex, Random.Range(minTime, maxTime)));
            }
            else if (maxTime > 10)
            {
                isSpawning = false;
                redCells[0].SetActive(false);
                return;
            }

            if (redCells.Length > 10)
            {
                isSpawning = false;
                maxTime = 0;

                if (maxTime > 10)
                {
                    StartCoroutine(SpawnObject(cellIndex, Random.RandomRange(5, 20)));
                }
            }
        }
        //Debug.Log("CellsNum " + cellCount);
    }
}
