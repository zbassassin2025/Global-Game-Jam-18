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

	public void LoadStart(){

		SceneManager.LoadScene("Start Scene");
	}

	public void GameScene(){

		SceneManager.LoadScene("Kuan's Scene");
	}

	public void ControlScene(){

		SceneManager.LoadScene("Controls");
	}

	public void CreditsScene(){
		SceneManager.LoadScene("Credits");

	}

	public void QUit(){

		SceneManager.LoadScene("Start Scene");
	}

	public void Restart(){

		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void End(){

		Application.Quit();
	}

}
