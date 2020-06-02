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

    int adressNumber;
    District homeDistrict;
    bool isMoving;

    public Tuple<District, int> HomeAdress {
        get
        {
            return new Tuple<District,int>(homeDistrict, adressNumber);
        }
    }

    public Tuple<District, int> TargetAdress{ get; private set; }

    public bool isInfected { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHome(District homeDistrict, int homeNumber)
    {
        this.homeDistrict = homeDistrict;
        this.adressNumber = homeNumber;
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
