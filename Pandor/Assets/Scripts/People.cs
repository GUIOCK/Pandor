using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class People : MonoBehaviour
{
    public enum District
    {
        NorthDistrict,
        WestDistrict,
        EastDistrict,
        SouthDistrict,
        CentralDistrict
    }

    bool isMoving;

    public Tuple<District, int> HomeAdress { get; private set; }

    public Tuple<District, int> TargetAdress{ get; private set; }

    public bool isInfected { get; set; }

    void Start()
    {
        
    }

    void Update()
    {
        
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
}
