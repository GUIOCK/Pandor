using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class District : MonoBehaviour
{
    [SerializeField]
    private int maxBuildingNb;
    [SerializeField]
    private GameObject[] BuildingsTab;
    public static List<GameObject> DistrictList;

    // Start is called before the first frame update
    void Start()
    {
        DistrictList = new List<GameObject>();
        BuildingsTab = new GameObject[maxBuildingNb];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public GameObject GetBuilding(int index)
    {
        return BuildingsTab[index];
    }

    public Vector3 GetBuildingPosition(GameObject building)
    {
        return building.transform.position;
    }
}
