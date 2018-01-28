using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowXY : MonoBehaviour {

    //public GameObject player;
    public float distance;
	[SerializeField]
	private float xMax;
	[SerializeField]
	private float xMin;
	[SerializeField]
	private float yMax;
	[SerializeField]
	private float yMin;

	public Transform target;
	// Use this for initialization
	/*
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
       // transform.position = player.transform.position + new Vector3(0,0,-1); //moves to coordinates of player at start
        //offset = transform.porition;
	}
	*/
	void Start() {
		target = GameObject.FindGameObjectWithTag("Player").transform;
	}

	// Update is called once per frame
	void LateUpdate () {
        //Vector3 pos = player.transform.position;
        //transform.position = new Vector3(pos.x, pos.y, distance);
       // CameraFollow.position = offset(player.position);

		transform.position = new Vector3 (Mathf.Clamp(target.position.x, xMin, xMax), Mathf.Clamp(target.position.y, yMin, yMax), distance);
	}
}
