using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleInfection : MonoBehaviour
{
    private People people;

    public CalculInfection calInf { get; set; }

    public bool isInfected { get; set; }

    public void Start()
    {
        isInfected = false;
        people = GetComponent<People>();
        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player")
            //&& (people.isInfected || other.gameObject.GetComponent<People>().isInfected)
            )
        {
            this.isInfected = TransmissionByCollision(isInfected);
            Debug.Log(isInfected);
        }
    }

    public bool TransmissionByCollision(bool isInfected)
    {
        float increment = 0;

        Random aleatoire = new Random();

        if (!isInfected)
        {
            increment = calInf.Increment();
            Debug.Log("Le risque en pourcentage : " + increment + " %");
            if (Random.Range(0, 100) < increment)
            {
                return true;
            }
            return false;
        }

        return isInfected;
    }
}
