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
        spawnCount = 0;
    }

    private void Update()
    {
        spawnTime += Time.time;
        Debug.Log(spawnTime);

        for(int i = 0; i < spawnCount; i++)
        {
            spawnCount++;
            StartCoroutine(Spawn());
        }

        if(spawnCount >= 10)
        {
            StopCoroutine(Spawn());
        }
    }

   private IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3.0f);

        if (spawnTime >= 3)
        {
            Debug.Log("Added cell");
            Instantiate(redCell, transform.position, transform.rotation);
        }

        spawnTime = 0;

        yield return new WaitForSeconds(1.0f);
	}
}