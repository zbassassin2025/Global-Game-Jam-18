using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCellMovement : MonoBehaviour {
    //Every 30 frames, updates vector to change slightly
    //Every 200 frames, update vector to change in a large angle
    public float[] angles = {45f, -45f, -90f, -180f, 90f, 180f};
    private Rigidbody redCell;
    Vector2 startingPosition;
    float randomX;
    float randomY;
    //float largeX;
    //float largeY;
    public float speed = 6f;


    void WobbleObject()
    //Changes vector by small random number
    {
        randomX = Random.Range(-1.0f, 1.0f);
        randomY = Random.Range(-1.0f, 1.0f);
        startingPosition = new Vector2(randomX, randomY);

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

    void LargeMovement()
    // Changes angle by random angle from list
    {
        int index = Mathf.FloorToInt(Random.Range(0, angles.Length));
        Debug.Log(index);
        //startingPosition.Set(Mathf.Cos(angles[index]), Mathf.Sin(angles[index]));
        //transform.rotation = Quaternion.Euler(Mathf.Cos(angles[index]), Mathf.Sin(angles[index]), 0);
        redCell.AddForce(Vector2.zero);
        redCell.rotation = Quaternion.Euler(Mathf.Cos(angles[index]), Mathf.Sin(angles[index]), 0);
        //startingPosition.Set(randomX*Mathf.Cos(angles[index]), randomY*Mathf.Sin(angles[index]));
    }

    // Use this for initialization
    void Start () {
        redCell = GetComponent<Rigidbody>();

    }

    // Update is called once per frame
    void Update () {
        if (Time.frameCount % 30 == 0)
        {
            WobbleObject();
        }
        if (Time.frameCount % 120 == 0)
        {
            LargeMovement();
            Debug.Log(startingPosition);
        }
        redCell.AddForce(startingPosition * speed);
        
    }
}
