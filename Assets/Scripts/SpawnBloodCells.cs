using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBloodCells : MonoBehaviour {
    public GameObject redCell;
    public float spawnTime = 0f;

	// Use this for initialization
	void Start ()
    {
       // InvokeRepeating("Spawn", spawnTime, spawnTime);
        spawnTime = 0;
        StartCoroutine("SpawnTimer");
    }

    private void Update()
    {
        spawnTime += Time.time;
    }

    private void LateUpdate()
    {
        StartCoroutine("SpawnTimer");
    }

    /*void Update()
    {
        Debug.Log(spawnTime);
        spawnTime += Time.time;

        if (spawnTime >= 3)
        {
            Spawn();
        }
        else
        {
            return;
        }

    }
    */


    private IEnumerator SpawnTimer()
    {
        yield return new WaitForSeconds(10.0f);
        Debug.Log(spawnTime);

        if (spawnTime >= 3)
        {
            yield return new WaitForSeconds(10.0f);
            StartCoroutine("Spawn");
            yield return new WaitForSeconds(5.0f);
        }
    }

    // Update is called once per frame
   private IEnumerator Spawn()
    {
        StopCoroutine("Spawn");
        while(true)
        {
            if (spawnTime >= 3)
            {
                Debug.Log("Added cell");
                Instantiate(redCell, transform.position, transform.rotation);
                yield break;

            }
        }
      

        spawnTime = 0;

        yield return new WaitForSeconds(1.0f);
	}
}
