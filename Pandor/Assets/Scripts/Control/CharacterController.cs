using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterController : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool isArrived = false;
    public float tagetX;

    [SerializeField] private GameObject building;

    private Vector3 target;
    private Vector3 house;
    private float timeStaying = 5f;
    private Building build;


    private int stayHomePercentage = 70;

    private int goToPeoplePercentage = 85;

    private int goToCenterPercentage = 99;
    [SerializeField]
    private bool isInMovement = false;

    // Update is called once per frame
    private void Start()
    {
        build = building.GetComponent<Building>();
        //target = GenerateTarget();
        house = transform.position;

    }


    void FixedUpdate()
    {
        GenerateAction();
        if (transform.position == house)
        {
            Debug.Log("Je suis à la maison");
            isInMovement = false;
        }

        //Debug.Log("ma pos : " + transform.position);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    agent.SetDestination(target);
        //}
        //else if (isArrived)
        //{
        //    isArrived = false;
        //    InvokeRepeating("DestinationToHouse", timeStaying, 10f);
        //}
    }


    public void DestinationToHouse()
    {
        agent.SetDestination(house);
        //isInMovement = false;
        CancelInvoke();
    }


    /*private Vector3 GenerateTarget()
    {
        //int randTarget = Random.Range(0, build.getBuildings.Length);
        //GameObject theTarget = build.getBuildings[randTarget];
        //return theTarget.transform.position;
    }*/

    private void GenerateAction()
    {
        if (Random.Range(0, 3600) < 20 && !isInMovement)
        {
            int chooseAction = Random.Range(0, 100);
            Debug.Log(isArrived);
            if (chooseAction <= stayHomePercentage)
            {
                Debug.Log("Pas voir copaing");
                isInMovement = false;
            }
            else if (chooseAction <= goToPeoplePercentage)
            {
                Debug.Log("Voir copaing !!");
                isInMovement = true;
                agent.SetDestination(target);
                
            }
            else if (chooseAction <= goToCenterPercentage)
            {
                Debug.Log("Peut être copaing ?");
                isInMovement = true;
                agent.SetDestination(target);
                
            }
            else
            {
                Debug.Log("WTF");
            }
        }
        if (isArrived)
        {
            //Debug.Break();
            isArrived = false;
            InvokeRepeating("DestinationToHouse", timeStaying, 10f);
        }
    }

}
