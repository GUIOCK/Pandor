using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Building : MonoBehaviour
{
    [SerializeField] private GameObject[] allBuilding;

    private GameObject[] house;

    public GameObject[] getBuildings
    {
        get { return allBuilding; }
    }

    public GameObject[] arrayHouse
    {
        get { return house; }
    }
    // Start is called before the first frame update
    void Awake()
    {
        house = GameObject.FindGameObjectsWithTag("House");
    }


}
