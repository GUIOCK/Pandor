using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class District : MonoBehaviour
{
    private List<GameObject> BuildingsTab;
    public static List<GameObject> DistrictList;

    [SerializeField]
    public string DistrictName;

    // Start is called before the first frame update
    void Start()
    {
        DistrictList = new List<GameObject>();
        BuildingsTab = new List<GameObject>();
        Debug.Log("Child Count " + DistrictName + " " + transform.childCount);
        IterateGetChild(transform);
    }

    void IterateGetChild(Transform transformChild)
    {
        for (int i = 0; i < transformChild.childCount; i++)
        {
            if (transformChild.GetChild(i).GetComponent<Building>())
            {
                BuildingsTab.Add(transformChild.GetChild(i).gameObject);
            }
            if (transformChild.GetChild(i).childCount > 0)
            {
                IterateGetChild(transformChild.GetChild(i));
            }
        }
    }

    public void StartGame(int preInfected)
    {
        Debug.Log("BuildingsTab : " + BuildingsTab.Count);
        int preInfectedDistrict = Random.Range(0, BuildingsTab.Count);
        for(int i = 0; i < BuildingsTab.Count; i++)
        {
            if(i == preInfectedDistrict)
            {
                BuildingsTab[i].GetComponent<Building>().preInfected = preInfected;
            }
            BuildingsTab[i].GetComponent<Building>().StartGame();
        }
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
