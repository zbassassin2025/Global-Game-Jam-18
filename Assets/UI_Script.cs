using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Script : MonoBehaviour {

	public GameObject[] blood; //blood.Length
	public GameObject[] virus; //virus.Length
	public GameObject player;
	public GameObject gameManager; //checks for updated scores
	public float score; //updating score
	public Text hp;
	public Text bc;
	public Text vc;
	public Text sc;
	public int blood_count;
	public int virus_count;

	void Awake(){

		player = GameObject.FindGameObjectWithTag("Player");

	}


	// Use this for initialization
	void Start () {
		virus = GameObject.FindGameObjectsWithTag("Virus");
		blood = GameObject.FindGameObjectsWithTag("Blood");
		blood_count = blood.Length;
		virus_count = virus.Length;

	}
	
	// Update is called once per frame
	void Update () {

	}


	void FixedUpdate(){
		sc.text = "Score: " + score; 
		bc.text = "Blood Count: " + blood_count;
		vc.text = "Virus Count: " + virus_count;
		hp.text = "Life Point: " + player.GetComponent<PlayerStats>().hp.ToString();
	}

}
