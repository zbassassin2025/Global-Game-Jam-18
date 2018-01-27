using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovement : MonoBehaviour {

    public float speed = 100f;
    private Rigidbody2D rb;
    Vector2 startingPosition;
    float randomX;
    float randomY;

    // Use this for initialization
    IEnumerator Start () {
        rb = GetComponent<Rigidbody2D>();
        yield return StartCoroutine(WaitAndPrint(0.5F));
        print("Done " + Time.time);
    }

    void MovePlayer()
    //Changes Player's current vector by random number
    {
        randomX = Random.Range(-1.0f, 1.0f);
        randomY = Random.Range(-1.0f, 1.0f);
        Debug.Log(Time.deltaTime);
        startingPosition = new Vector2(randomX, randomY);
        rb.AddForce(startingPosition * speed);

        Debug.Log(startingPosition);
        if (-1.0f <= randomX && randomX <= 1.0f)
        {
            randomX += Random.Range(-0.3f, 0.3f);
        }
        if (-1.0f <= randomY && randomY <= 1.0f)
        {
            randomY += Random.Range(-0.3f, 0.3f);
        }
        startingPosition.Set(randomX, randomY);
    }


    // Update is called once per frame
    IEnumerator WaitAndPrint (float waitTime) {

        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            MovePlayer();
        }
        //transform.position = Random.insideUnitSphere * 2;
	}
}
