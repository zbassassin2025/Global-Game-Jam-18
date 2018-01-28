﻿using System.Collections;
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
	public GameObject pause_canvas;
	public int blood_count;
	public int virus_count;
	private float cooldown;
	private float cooldowntime = 1f;

	void Awake(){
		Time.timeScale = 1;
		player = GameObject.FindGameObjectWithTag("Player");
		pause_canvas.SetActive(false);
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
		if(Input.GetKeyDown(KeyCode.Escape)){
			if(Time.timeScale == 1){
				Time.timeScale = 0;
				pause_canvas.SetActive(true);

			}else if (Time.timeScale == 0){
				Time.timeScale = 1;
				pause_canvas.SetActive(false);

			}

		}

	}


	void FixedUpdate(){
		sc.text = "Score: " + score; 
		bc.text = "Blood Count: " + blood_count;
		vc.text = "Virus Count: " + virus_count;
		hp.text = "Life Point: " + player.GetComponent<PlayerStats>().hp.ToString();
	}

}
