using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionScript : MonoBehaviour {
    //test

    public float _movementSpeed;
    public float _virusDistance;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        GameObject virus = GameObject.FindWithTag("Virus");

        if(virus == null)
        {
            transform.Translate(Vector2.up * Time.deltaTime * _movementSpeed);
        }
        else
        {
            float fVirusDistance = (transform.position - virus.transform.position).sqrMagnitude;

            if (fVirusDistance < _virusDistance)
            {
                transform.position = Vector2.Lerp(transform.position, virus.transform.position, _movementSpeed);
            }
            else
            {
                transform.Translate(Vector2.up * Time.deltaTime * _movementSpeed);
            }

        }

    }
}
