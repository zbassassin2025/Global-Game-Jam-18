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
		//GetComponentInParent<VirusScript>().isNotOnBlood = false;
		GameObject n_virus = Instantiate(virus, transform.position, Quaternion.identity) as GameObject;
		GameObject n_virus2 = Instantiate(virus, transform.position, Quaternion.identity) as GameObject;
		n_virus.SetActive(true);
		n_virus.GetComponentInParent<VirusScript>().isNotOnBlood = false;
		n_virus2.SetActive(true);
		n_virus2.GetComponentInParent<VirusScript>().isNotOnBlood = false;

		Destroy(transform.parent.gameObject);
	}


}
