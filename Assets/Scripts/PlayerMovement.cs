using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
	public float max_x;
	public float max_y;
	public float min_x;
	public float min_y;
	public bool active_position_check = false;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
	}
		
	void Update(){
		//checks for player position


		//making sure player position isnt out of bound


	}

	// Update is called once per frame
	void FixedUpdate () {

		float moveHorizontal = Input.GetAxis("Horizontal"); 
		float moveVertical = Input.GetAxis("Vertical");
		//Debug.Log("v: " + moveVertical + " h: " + moveHorizontal);

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

		Vector3 pposition = transform.position; 

		if(active_position_check){
		if(pposition.x > max_x){

			transform.position = new Vector2(max_x, pposition.y);
			movement = Vector2.zero;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		if(pposition.x < min_x){
			transform.position = new Vector2(min_x, pposition.y);
			movement = Vector2.zero;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		if(pposition.y > max_y){

			transform.position = new Vector2(pposition.y, max_y);
			movement = Vector2.zero;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
		}
		if(pposition.y < min_y){
			transform.position = new Vector2(pposition.y, min_y);
			movement = Vector2.zero;
			GetComponent<Rigidbody>().velocity = Vector3.zero;
			}
		}

		rb.AddForce(movement * speed);
	}
}
