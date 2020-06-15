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

    // Update is called once per frame
    private void Start()
    {
        build = building.GetComponent<Building>();
        target = GenerateTarget();
        house = transform.position;
        
    }


    void Update()
    {
        Debug.Log("ma pos : " + transform.position);
		if (Input.GetMouseButtonDown(0))
		{
            agent.SetDestination(target);
        }
        else if (isArrived)
        {
            isArrived = false;
            InvokeRepeating("DestinationToHouse", timeStaying, 10f);
            
        }
    }


    public void DestinationToHouse()
    {
        agent.SetDestination(house);
        CancelInvoke();
    }


    private Vector3 GenerateTarget()
    {
        int randTarget = Random.Range(0, build.getBuildings.Length);
        GameObject theTarget = build.getBuildings[randTarget];
        return theTarget.transform.position;
    }

}
