using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class People : MonoBehaviour
{
    public enum EnumChoice
    {
        home,
        people,
        center,
        WTF
    }

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
    PeopleInfection peopleCollision;

    public bool isInfected { get; set; }
    public CalculInfection calculInfection { get; set; }
    void Awake()
    {
        gameObject.tag = "Player";
    }
    void Start()
    {
        peopleCollision = gameObject.AddComponent<PeopleInfection>();
        meshRenderer = GetComponent<MeshRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
        capsuleCollider.isTrigger = true;
        peopleCollision.calInf = calculInfection;
        peopleCollision.Start();
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
        isInfected = peopleCollision.isInfected;
    }

    private void SetTarget()
    {
        EnumChoice choice = setChoice(70, 20, 10);
        switch (choice)
        {
            case EnumChoice.home:
                target = home;
                break;
            case EnumChoice.center:
                target = centers[Random.Range(0, centers.Count)];
                break;
            case EnumChoice.people:
                target = friends[Random.Range(0, friends.Count)];
                break;
            default:
                Debug.Log("WTF");
                break;
        }
    }

    public void Move()
    {
        SetVisible(true);

        agent.isStopped = false;
        agent.SetDestination(target.transform.position);
    }
    public void Stop()
    {
        SetVisible(false);
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
        this.friends.Add(friend);
    }

    public void AddCenter(GameObject center)
    {
        if (this.centers == null)
        {
            this.centers = new List<GameObject>();
        }
        this.centers.Add(center);
    }

    public void SetVisible(bool isVisible)
    {
        //meshRenderer.enabled = isVisible;
        capsuleCollider.enabled = isVisible;
        transform.Find("skin").GetComponent<SkinPNJ>().SendMessage("IsVisible", isVisible);
    }

    public GameObject GetTarget()
    {
        return target;
    }

    public EnumChoice setChoice(int percentHome, int percentPeople, int percentCenter)
    {
        if (percentHome + percentPeople + percentCenter == 100)
        {
            int rand = Random.Range(0, 100);
            if (rand < percentHome)
            {
                return EnumChoice.home;
            }
            else if (rand < percentPeople + percentHome)
            {
                return EnumChoice.people;
            }
            else
            {
                return EnumChoice.center;
            }
        }
        else
        {
            return EnumChoice.WTF;
        }
    }
}
