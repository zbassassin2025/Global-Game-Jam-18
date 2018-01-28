using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class virus_animation : MonoBehaviour {


	public GameObject virus;

	// Use this for initialization
	void Start () {

		//Changing tag for this specific one
		virus = GameObject.FindGameObjectWithTag("Virus");
	}
	
	// Update is called once per frame
	void Update () {
		virus = GameObject.FindGameObjectWithTag("Virus");
	}

	public void DestroyVirus(){

		Instantiate(virus, transform.position, Quaternion.identity).SetActive(true);
		Destroy(transform.parent.gameObject);
	}


}
