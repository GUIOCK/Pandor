using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class People : MonoBehaviour
{
    [SerializeField] private List<GameObject> friends;
    [SerializeField] private List<GameObject> centers;
    public GameObject home;

    public NavMeshAgent agent;
    private GameObject target;
    private GameObject actualPosition;
    private int stayHomePercentage = 70;
    private int goToPeoplePercentage = 85;
    private int goToCenterPercentage = 99;
    private float timer = 25;
    private bool isMoving;
    MeshRenderer meshRenderer;
    CapsuleCollider capsuleCollider;
    private GameObject[] playerModels;
    private GameObject actualPlayerModel;

    public bool isInfected { get; set; }
    void Awake()
    {
        gameObject.tag = "Player";
    }
    void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.isTrigger = true;
        playerModels = GameObject.FindGameObjectsWithTag("PlayerModel");
        //Debug.Log("Player model : " + playerModels);

        actualPlayerModel = playerModels[Random.Range(0, playerModels.Length - 1)];
        //Debug.Log("Player model : " + actualPlayerModel);
        //Debug.Break();
        SetActualPlayerModel();
    }

    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= 2 && !isMoving)
        {
            SetTarget();
            if (target != actualPosition)
            {
                isMoving = true;
                Move();
            }
        }
    }

    private void SetTarget()
    {
        int rand = Random.Range(1, 100);
        if (rand < stayHomePercentage)
        {
            target = home;
        }
        else if (rand < goToPeoplePercentage)
        {
            target = friends[Random.Range(0, friends.Count)];
        }
        else
        {
            target = centers[Random.Range(0, centers.Count)];
        }
    }

    public void Move()
    {
        SetVisible(true);

        agent.isStopped = false;
        /*NavMeshHit myNavHit;
        if (NavMesh.SamplePosition(transform.position, out myNavHit, 100, -1))
        {
            transform.position = myNavHit.position;
        }*/
        agent.SetDestination(target.transform.position);
    }
    public void Stop()
    {
        SetVisible(false);

        Debug.Log("Stopped !");
        agent.isStopped = true;
        timer = 0;
        isMoving = false;
        actualPosition = target;
    }

    public void AddFriend(GameObject friend)
    {
        if (this.friends == null)
        {
            this.friends = new List<GameObject>();
        }
        //if(friends.Find(go => friend == go) != null)
        //{
        this.friends.Add(friend);
        //}
    }

    public void AddCenter(GameObject center)
    {
        if (this.centers == null)
        {
            this.centers = new List<GameObject>();
        }
        //if (centers.Find(go => center == go) != null)
        //{
        this.centers.Add(center);
        //}
    }

    public void SetVisible(bool isVisible)
    {
        //meshRenderer.enabled = isVisible;
        capsuleCollider.enabled = isVisible;
        Debug.Log(actualPlayerModel);
        actualPlayerModel.GetComponent<SkinnedMeshRenderer>().enabled = isVisible;
    }

    public GameObject GetTarget()
    {
        return target;
    }

    private void SetActualPlayerModel()
    {
        foreach (GameObject model in playerModels)
        {
            if (model != actualPlayerModel)
            {
                model.SetActive(false);

            }
            else
            {
                Debug.Log("model : " + model);
                Debug.Log("actual model : " + actualPlayerModel);
                model.SetActive(true);
                Debug.Break();
                continue;
            }
        }
    }
}
