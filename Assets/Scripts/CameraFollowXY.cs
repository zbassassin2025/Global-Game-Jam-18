using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowXY : MonoBehaviour {

    public GameObject player;
    public float distance;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log(player);
       // transform.position = player.transform.position + new Vector3(0,0,-1); //moves to coordinates of player at start
        //offset = transform.porition;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        Vector3 pos = player.transform.position;
        transform.position = new Vector3(pos.x, pos.y, distance);
       // CameraFollow.position = offset(player.position);
	}
}
