using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Script Programmer: Zac Bogner
*/

public class VirusScript : MonoBehaviour
{
    [SerializeField]
    private float virusSpeed;
    public Transform virusPosition;
    public GameObject virusGameObject;
    public Transform playerPos;
    public GameObject target;

    private bool targetinRange = false;

    public float range = 5;

    public VirusID vID = VirusID.VirusAttack;

    private void Awake()
    {
        playerPos = FindObjectOfType<Transform>();
        target = FindObjectOfType<GameObject>();
        range = 5;
    }

    private void Start()
    {
        virusPosition = transform;
        virusGameObject.transform.position = virusPosition.position;
    }

    public enum VirusID
    {
        VirusAttack, 
        VirusMultiply,
        VirusDead
    }

    private void Update()
    {
        StartCoroutine(VirusAttack());
    }

    public IEnumerator VirusAttack()
    {
        yield return new WaitForSeconds(5f);

        float distance = Vector3.Distance(virusPosition.position, playerPos.position);

        if (vID == VirusID.VirusAttack)
        {
           if(distance < 5)
            {
                targetinRange = true;
            }
         
            if(targetinRange == true)
            {
                Debug.Log("enemy is close");
                virusPosition.LookAt(playerPos);
                Vector3 moveVirus = virusPosition.position;
                //  moveVirus.x = range;
            }

            Vector3 area = virusGameObject.transform.position - target.transform.position.normalized;
            float moveSpeed = virusSpeed * Time.deltaTime;
            virusGameObject.transform.position = target.transform.position + (area * moveSpeed);
            transform.LookAt(target.transform);
        }
        else
        {
            Debug.Log("not close yet " + distance);
        }

        yield return new WaitForSeconds(1.0f);
    }

    public IEnumerator VirusMultiply()
    {
        yield return null;
    }

    public IEnumerator VirusDead()
    {
        yield return null;
    }
}