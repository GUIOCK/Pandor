using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeopleCollision : MonoBehaviour
{
    [SerializeField]
    private GameObject foyerInfectieux;

    private CalculInfection calInf;

    [SerializeField]
    public bool isInfected { get; set; }

    private void Start()
    {
        Debug.Log("Am I even here ?");
        calInf = foyerInfectieux.GetComponent<CalculInfection>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            this.isInfected = PeopleInfection(isInfected);
            Debug.Log(isInfected);
        }
    }

    public bool PeopleInfection(bool isInfected)
    {
        int increment = 0;

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
