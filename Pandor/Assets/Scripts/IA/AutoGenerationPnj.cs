using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoGenerationPnj : MonoBehaviour
{
    public Vector3 targetPNJ;

    [SerializeField] private GameObject pnj;
    Building building;

    void Start()
    {
        building = GetComponent<Building>();
        //Debug.Log(building.arrayHouse);
        foreach (GameObject obj in building.arrayHouse)
        {
            GeneratePnj(obj);

        }
    }


    private void GeneratePnj(GameObject obj)
    {
        int nbPnjPerHouse = Random.Range(50, 50);
        Vector3 initPosition;
        for (int i = 1; i < nbPnjPerHouse; i++)
        {
            initPosition = new Vector3(obj.transform.position.x + i, obj.transform.position.y, obj.transform.position.z);
            Instantiate(pnj, initPosition, Quaternion.identity);
        }

    }


}
