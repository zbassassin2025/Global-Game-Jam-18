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

	void Start(){
		anim = GetComponentInChildren<Animator>();

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

    void OnCollisionEnter(Collision col) // destroy
    {
        if (col.transform.tag == "Blood")
		{
			Destroy(col.gameObject);
			anim.SetTrigger("bacteriophageInfection");
			//virus_animation();
			//Destroy(gameObject);

        }
    }

	IEnumerator virus_animation(){

		//anim.Play("BateriophageInfection");
		//float delay = 10f;
		anim.SetTrigger("bacteriophageInfection");
		//Debug.Log("time: " + anim.GetCurrentAnimatorStateInfo(0).length + delay); 
		//Destroy(gameObject, anim.GetCurrentAnimatorStateInfo(0).length + delay); 
	
		yield return null;
	}


}