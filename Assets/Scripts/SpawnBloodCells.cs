using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script Programmer: Zac Bogner
 */

public class SpawnBloodCells : MonoBehaviour
{
    public GameObject redCell;
    public float spawnTime = 0f;
    public int spawnCount = 0;

    void Start ()
    {
        spawnTime = 0;
        spawnCount = 10;
        StartCoroutine("SpawnTimer");
    }

    private void Update()
    {
        spawnTime += Time.time;

        while(redCell != null)
        {
            spawnCount += 1;
            StartCoroutine(SpawnTimer());
            if(spawnCount >= 10)
            {
                break;
            }
            else
            {
                StopCoroutine(SpawnTimer());
            }
        }
    }

    private IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(3.0f);
        Debug.Log(spawnTime);

        if (spawnTime >= 3)
        {
            yield return new WaitForSeconds(5.0f);
            StartCoroutine("Spawn");
            yield return new WaitForSeconds(5.0f);
        }
    }

   private IEnumerator Spawn()
    {
        StopCoroutine("Spawn");
        while(true)
        {
            if (spawnTime >= 3)
            {
                Debug.Log("Added cell");
                Instantiate(redCell, transform.position, transform.rotation);
            }

            spawnTime = 0;
            yield break;
        }

        yield return new WaitForSeconds(1.0f);
	}
}