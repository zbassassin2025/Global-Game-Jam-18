using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedBloodCellMovement : MonoBehaviour {
    //Every 30 frames, updates vector to change slightly
    //Every 200 frames, update vector to change in a large angle
    public int[] angles = {30, 45, 90, 180};
    private Rigidbody2D redCell;
    Vector2 startingPosition;
    float randomX;
    float randomY;
    public float speed = 6f;


    void WobbleObject()
    //Changes vector by small random number
    {
        randomX = Random.Range(-1.0f, 1.0f);
        randomY = Random.Range(-1.0f, 1.0f);
        Debug.Log(Time.deltaTime);
        startingPosition = new Vector2(randomX, randomY);

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

    void LargeMovement()
    {

    }

    // Use this for initialization
    void Start () {
        redCell = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update () {
        if (Time.frameCount % 30 == 0)
        {
            WobbleObject();
        }
        if (Time.frameCount % 200 == 0) ;
        redCell.AddForce(startingPosition * speed);

    }
}
