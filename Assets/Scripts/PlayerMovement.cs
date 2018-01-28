using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {
    public float speed;
    private Rigidbody rb;
	public float max_x;
	public float max_y;
	public float min_x;
	public float min_y;
	public bool active_position_check = false;
    public GameObject _antibodyPrefab;
    public int _maxAntibody;

    private float _coolDown = 0.0f;

    private Queue<GameObject> _antibodyQueue;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        _antibodyQueue = new Queue<GameObject>();
	}
		
	void Update(){
        //checks for player position


        //making sure player position isnt out of bound

        ReleaseAntiBody();


	}

	// Update is called once per frame
	void FixedUpdate () {

		rb.velocity = new Vector3(0.0f, 0.0f, 0.0f);
		float moveHorizontal = Input.GetAxis("Horizontal")/2; 
		float moveVertical = Input.GetAxis("Vertical")/2;
        //Debug.Log("v: " + moveVertical + " h: " + moveHorizontal);

        this.transform.position += new Vector3(moveHorizontal, moveVertical);

        Vector3 movement = new Vector3(moveHorizontal, moveVertical, 0);

        Vector3 pposition = transform.position;

        if (active_position_check)
        {
            if (pposition.x > max_x)
            {
                Debug.Log("beyond max x");
                transform.position = new Vector2(max_x, pposition.y);
                movement = Vector2.zero;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (pposition.x < min_x)
            {
                Debug.Log("beyond min x");
                transform.position = new Vector2(min_x, pposition.y);
                movement = Vector2.zero;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (pposition.y > max_y)
            {
                Debug.Log("beyond max y");
                transform.position = new Vector2(pposition.y, max_y);
                movement = Vector2.zero;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
            if (pposition.y < min_y)
            {
                Debug.Log("beyond min y");
                transform.position = new Vector2(pposition.y, min_y);
                movement = Vector2.zero;
                GetComponent<Rigidbody>().velocity = Vector3.zero;
            }
        }

        //rb.AddForce(movement * speed);
        rb.MovePosition(movement * speed * Time.deltaTime + transform.position);
	}

    private void ReleaseAntiBody()
    {
        
        if (Input.GetKeyDown("space") && ContainsButtonPresses())
        {
            //Shoot antibodies
            var direction = (Vector3)ProjectionScript.GetDirectionByKey() * 2;

            var antibody = Instantiate(_antibodyPrefab, transform.position + direction, Quaternion.identity) as GameObject;
            antibody.AddComponent<BoxCollider>();


            _antibodyQueue.Enqueue(antibody);

            if(_antibodyQueue.Count > _maxAntibody)
            {
                Debug.Log("deleting antibody...");
                var removedAntibody = _antibodyQueue.Dequeue();
                removedAntibody.SetActive(false);
                Destroy(removedAntibody);
            }

        }
    }

    private bool ContainsButtonPresses()
    {
        return Input.GetAxis("Horizontal") != 0.0f || Input.GetAxis("Vertical") != 0.0f;
    }
}
