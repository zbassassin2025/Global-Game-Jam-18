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

    public IEnumerator VirusAttack()
    {
        yield return new WaitForSeconds(5f);

        if (vID == VirusID.VirusAttack)
        {
            if (Vector3.Distance(virusPosition.position, playerPos.position) <= range)
            {
                virusPosition.LookAt(playerPos);
                Vector3 moveVirus = virusPosition.position;
                moveVirus.x = range;
            }

            Vector3.MoveTowards(virusGameObject.transform.position, target.transform.position, range);
        }
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