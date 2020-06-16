﻿using System;
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
    }
    void Start()
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
        int nbPeople = Random.Range(1, 4);
        Debug.Log("Building " + gameObject.name + " a " + nbPeople);
        for (int i = 0; i < nbPeople; i++)
        {
            GameObject npc = Instantiate(this.npc,transform.position,transform.rotation);
            People npcComponent = npc.GetComponent<People>();
            npcComponent.home = this.gameObject;
            int nbFriends = Random.Range(1, 5);
            for (int j = 0; j < nbFriends; j++)
            {
                npcComponent.AddFriend(homeBuildings[Random.Range(0, homeBuildings.Count)]);
            }
            npcComponent.AddCenter(centerBuildings[Random.Range(0, centerBuildings.Count)]);
        }
    }
}
