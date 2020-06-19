using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Building : MonoBehaviour
{
    static private List<GameObject> homeBuildings;
    static private List<GameObject> centerBuildings;
    [SerializeField] private GameObject npc;
    [SerializeField] private BuildingType buildingType;
    public int preInfected { get; set; }
    enum BuildingType
    {
        Home,
        Center
    }

    // Start is called before the first frame update
    void Awake()
    {
        //house = GameObject.FindGameObjectsWithTag("House");
        gameObject.tag = "Building";
        preInfected = 0;
    }

    public void StartGame()
    {
        GameObject[] buildings = GameObject.FindGameObjectsWithTag("Building");
        Tuple<List<GameObject>, List<GameObject>> tuple = SetBuildingsType(buildings);
        homeBuildings = tuple.Item1;
        centerBuildings = tuple.Item2;

        MeshCollider[] colliders = GetComponents<MeshCollider>();
        foreach (MeshCollider collider in colliders)
        {
            collider.isTrigger = true;
        }

        if (buildingType == BuildingType.Home)
        {
            SetupNPCs();
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            People peopleComponent = other.gameObject.GetComponent<People>();
            GameObject target = peopleComponent.GetTarget();
            if(this.gameObject == target)
            {
                peopleComponent.SendMessage("Stop");
            }
        }
    }

    Tuple<List<GameObject>, List<GameObject>> SetBuildingsType(GameObject[] buildings)
    {
        List<GameObject> homes = new List<GameObject>();
        List<GameObject> centers = new List<GameObject>();

        foreach (GameObject building in buildings)
        {
            switch (building.GetComponent<Building>().buildingType)
            {
                case BuildingType.Home:
                    homes.Add(building);
                    break;
                case BuildingType.Center:
                    centers.Add(building);
                    break;
                default:
                    break;
            }
        }
        return new Tuple<List<GameObject>, List<GameObject>>(homes, centers);
    }

    void SetupNPCs()
    {
        int nbPeople;

        if (preInfected != 0)
        {
            nbPeople = Random.Range(preInfected, preInfected + 4);
        }
        else
        {
            nbPeople = Random.Range(1, 4);
        }

        for (int i = 0; i < nbPeople; i++)
        {
            GameObject npc = Instantiate(this.npc,transform.position,transform.rotation);
            People npcComponent = npc.GetComponent<People>();
            npcComponent.home = this.gameObject;
            npcComponent.calculInfection = GetComponentInParent<CalculInfection>();
            int nbFriends = Random.Range(1, 5);
            for (int j = 0; j < nbFriends; j++)
            {
                npcComponent.AddFriend(homeBuildings[Random.Range(0, homeBuildings.Count)]);
            }
            npcComponent.AddCenter(centerBuildings[Random.Range(0, centerBuildings.Count)]);
            if(preInfected != 0)
            {
                Debug.Log("Le isInfected dans la création : ");
                Debug.Log(npcComponent.isInfected);
                npcComponent.isInfected = true;
                Debug.Log(npcComponent.isInfected);
            }
        }
    }
}
