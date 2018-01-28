using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectionScript : MonoBehaviour {
    //test

    public float _movementSpeed;
    public float _virusDistance;
    public float _destroyTime;

    private Vector2 _directionAtInstantiate;

	// Use this for initialization
	void Start () {
        _directionAtInstantiate = GetDirectionByKey();
	}
	
	// Update is called once per frame
	void Update () {
        GameObject virus = GameObject.FindWithTag("Virus");

        if(virus == null)
        {
            transform.Translate(_directionAtInstantiate * Time.deltaTime * _movementSpeed);
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
            DestroyAntiBody();

        }
    }

    private Vector2 GetDirectionByKey()
    {
        //Up-Left
        if (Input.GetAxisRaw("Vertical") > 0.0f && Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            return Vector2.up + Vector2.left;
        }

        //Up-Right
        if (Input.GetAxisRaw("Vertical") > 0.0f && Input.GetAxisRaw("Horizontal") > 0.0f)
        {
            return Vector2.up + Vector2.right;
        }

        //Down-Right
        if (Input.GetAxisRaw("Vertical") < 0.0f && Input.GetAxisRaw("Horizontal") > 0.0f)
        {
            return Vector2.down + Vector2.right;
        }

        //Down-Left
        if (Input.GetAxisRaw("Vertical") < 0.0f && Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            return Vector2.down + Vector2.left;
        }

        //Left
        if (Input.GetAxisRaw("Horizontal") < 0.0f)
        {
            return Vector2.left;
        }

        //Right
        if (Input.GetAxisRaw("Horizontal") > 0.0f)
        {
            return Vector2.right;
        }

        //Down
        if (Input.GetAxisRaw("Vertical") < 0.0f)
        {
            return Vector2.down;
        }

        //Up
        if (Input.GetAxisRaw("Vertical") > 0.0f)
        {
            return Vector2.up;
        }

        return new Vector2(0,0);
    }

    private void DestroyAntiBody()
    {
        Destroy(this, _destroyTime);
        this.gameObject.SetActive(false);
    }
}
