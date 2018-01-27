using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionScript : MonoBehaviour {
    //test

    public float _movementSpeed;
    public float _virusDistance;
    public float _destroyTime;

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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collided against: " + collision.gameObject.name);
        if(collision.collider.tag == "Virus")
        {
            //Kill virus, destroy projectile
            collision.gameObject.SetActive(false);

            // JA: Contract : Once Virus has a DestroyUponContact function, replace
            // this with the Virus's Destory function
            Destroy(collision.gameObject, _destroyTime);

            // JA: Contract: Implement a function that destroys the object with animation
            Destroy(this, _destroyTime);
            this.gameObject.SetActive(false);

        }
    }
}
