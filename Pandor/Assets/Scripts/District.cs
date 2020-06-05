using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class District : MonoBehaviour
{
    [SerializeField]
    private int maxBuildingNb;
    private GameObject[] BuildingsTab;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetBuilding(int index)
    {
        return BuildingsTab[index];
    }
}
