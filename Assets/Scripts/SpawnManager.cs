using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour {


	public int number_to_spawn;
	public int spawned = 0;
	public GameObject[] spawners;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (number_to_spawn != 0 && spawned != number_to_spawn){
			//call spawners
			for(int i = 0; i < spawners.Length; i++){
				spawners[i].GetComponent<spawningScript>().SpawnPrefab();
				//call spawner spawn function;
				spawned++;
				if(spawned == number_to_spawn)
				{break;}

			}
		}
	}
}
