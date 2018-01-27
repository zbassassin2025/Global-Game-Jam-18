using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireScript : MonoBehaviour {

	public float cd;
	public float cdtimer = 0.1f;
	public GameObject bullet;
	public GameObject bulletobj;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKey(KeyCode.Space) && cd < Time.time)
		{

			Vector3 ins_pos = GetComponent<Rigidbody>().velocity;


			bulletobj = Instantiate(bullet, ins_pos , Quaternion.identity) as GameObject;
			bulletobj.AddComponent<Rigidbody>();
			bulletobj.AddComponent<SphereCollider>();
			cd += Time.time + cdtimer;

		}
	}
}
