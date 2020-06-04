using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class CharacterController : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool isArrived;
    public float tagetX;

    [SerializeField] private GameObject market;

    private Vector3 target;
    private Vector3 house;
    private float timeStaying = 5f;

    // Update is called once per frame
    private void Start()
    {
        target = new Vector3(tagetX, transform.position.y, -5.4f);
        //house = new Vector3(0f, 0f, 0f);
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


}
