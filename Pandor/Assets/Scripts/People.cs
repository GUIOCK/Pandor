using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class People : MonoBehaviour
{
    [SerializeField]
    District homeDistrict;
    [SerializeField]
    int homeAdress;

    public enum District
    {
        NorthDistrict,
        WestDistrict,
        EastDistrict,
        SouthDistrict,
        CentralDistrict
    }

    [SerializeField]
    bool isMoving;
    bool moved = false;

    public Tuple<District, int> HomeAdress { get; private set; }

    public Tuple<District, int> TargetAdress { get; private set; }

    public bool isInfected { get; set; }

    float currentLerpTime = 0;
    Vector3 currentPosition;

    MeshRenderer meshRenderer;
    CapsuleCollider capsuleCollider;

    void Start()
    {
        SetHome(homeDistrict, homeAdress);
        currentPosition = transform.position;
        meshRenderer = GetComponent<MeshRenderer>();
        capsuleCollider = GetComponent<CapsuleCollider>();
    }

    void Update()
    {
        if (Random.Range(0, 1000) < 10 && !moved)
        {
            SetTarget(District.SouthDistrict, 5);
        }

        if (this.TargetAdress != null)
        {
            isMoving = true;
        }

        if (isMoving)
        {
            SetVisible(true);
            MoveToPosition(currentPosition, new Vector3(-7, 1, -2.5f), 5);
            if (transform.position == new Vector3(-7, 1, -2.5f))
            {
                isMoving = false;
                moved = true;
                ResetTarget();
            }
        }
        else
        {
            SetVisible(false);
        }
    }

    public void SetHome(District homeDistrict, int homeNumber)
    {
        this.HomeAdress = new Tuple<District, int>(homeDistrict, homeNumber);
    }

    public void ResetTarget()
    {
        this.TargetAdress = null;
    }

    public void SetTarget(District targetDistrict, int targetNumber)
    {
        this.TargetAdress = new Tuple<District, int>(targetDistrict, targetNumber);
    }

    public void SetVisible(bool isVisible)
    {
        if (isVisible)
        {
            meshRenderer.enabled = true;
            capsuleCollider.enabled = true;
        }
        else
        {
            meshRenderer.enabled = false;
            capsuleCollider.enabled = false;
        }
    }

    public void MoveToPosition(Vector3 currentPosition, Vector3 targetPosition, float trajectTime)
    {
        currentLerpTime += Time.deltaTime;
        if (currentLerpTime >= trajectTime)
        {
            currentLerpTime = trajectTime;
        }
        float perc = currentLerpTime / trajectTime;
        transform.position = Vector3.Lerp(currentPosition, targetPosition, perc);
    }
}
