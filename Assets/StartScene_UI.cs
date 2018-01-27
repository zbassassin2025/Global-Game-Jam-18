using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene_UI : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void StartScene(){

		SceneManager.LoadScene("Game Stage 1");
	}

	public void ControlScene(){

		SceneManager.LoadScene("Controls");
	}

	public void CreditsScene(){
		SceneManager.LoadScene("Credits");

	}


}
