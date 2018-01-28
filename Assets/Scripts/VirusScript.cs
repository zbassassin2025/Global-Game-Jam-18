using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script Programmer: Zac Bogner
*/

public class VirusScript : MonoBehaviour
{
    public float virusSpeed = 0;

    public GameObject virus;
    public GameObject player;
	public Animator anim;
	public float[] angles = {45, -45f, -90f, -180f, 90f, 180f};
	float randomX;
	float randomY;
	public float speed = 6f;
	Vector2 startingPosition;
	public bool isNotOnBlood = false;

	void Start(){
		anim = GetComponentInChildren<Animator>();

	}

 

	void Update(){
		if (Time.frameCount % 30 == 0)
		{
			RandomMove();
		}
		if (Time.frameCount % 120 == 0)
		{
			LargeMovement();
			//Debug.Log(startingPosition);
		}
		GetComponent<Rigidbody>().AddForce(startingPosition * speed);

	}


	void RandomMove(){
		randomX = Random.Range(-1.0f, 1.0f);
		randomY = Random.Range(-1.0f, 1.0f);
		startingPosition = new Vector2(randomX, randomY);
		if(-1.0f <= randomX && randomX <= 1.0f){
			randomX += Random.Range(-0.3f, 0.3f);

		}
		if(-1.0f <= randomY && randomY <= 1.0f){
			randomY += Random.Range(-0.3f, 0.3f);

		}
		startingPosition.Set(randomX, randomY);
	}

	void LargeMovement()
	// Changes angle by random angle from list
	{
		int index = Mathf.FloorToInt(Random.Range(0, angles.Length));
		//Debug.Log(index);
		//startingPosition.Set(Mathf.Cos(angles[index]), Mathf.Sin(angles[index]));
		//transform.rotation = Quaternion.Euler(Mathf.Cos(angles[index]), Mathf.Sin(angles[index]), 0);
		GetComponent<Rigidbody>().AddForce(Vector2.zero);
		GetComponent<Rigidbody>().rotation = Quaternion.Euler(Mathf.Cos(angles[index]), Mathf.Sin(angles[index]), 0);
		//startingPosition.Set(randomX*Mathf.Cos(angles[index]), randomY*Mathf.Sin(angles[index]));
	}



    public int bloodCells = 1;

    void OnTriggerEnter(Collider col)
    {/*
        if(col.tag == "Player")
        {
            GetComponent<Rigidbody>().AddForce(col.transform.position - transform.position);
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * virusSpeed;
        }*/
    }

    void OnTriggerStay(Collider col) // chasing
    {
		/*
        if (col.tag == "Player")
        {
            GetComponent<Rigidbody>().AddForce(col.transform.position - transform.position);
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * virusSpeed;
        }
*/
        if(col.tag == "Blood")
        {
            GetComponent<Rigidbody>().AddForce(col.transform.position - transform.position);
            GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity * virusSpeed;
        }
    }

	public void DestroyByAntibodyContact () {
		anim.SetTrigger ("bacteriophageDestroy");
	}
	
    void OnCollisionEnter(Collision col) // destroy
    {
        if (col.transform.tag == "Blood" && !isNotOnBlood)
		{
			isNotOnBlood = true;
			Destroy(col.gameObject);
			anim.SetTrigger("bacteriophageInfection");
			//virus_animation();
			//Destroy(gameObject);

        }
    }


}