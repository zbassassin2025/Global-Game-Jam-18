using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class spawningScript : MonoBehaviour {

	public GameObject prefab;//obj to spawn
	public float spawn_radius; //radius to spawn the unit 
	public float spawnXpos;
	public float spawnYpos;
	public float maxSpawnX;
	public float maxSpawnY;
	public float minSpawnX;
	public float minSpawnY;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		spawnXpos = Random.Range(minSpawnX, maxSpawnX);
		spawnYpos = Random.Range(minSpawnY, maxSpawnY);

	}

	public void SpawnPrefab(){
		Instantiate(prefab, new Vector3(transform.position.x + spawnXpos, transform.position.y + spawnYpos, 0) , Quaternion.identity);

	}



}
