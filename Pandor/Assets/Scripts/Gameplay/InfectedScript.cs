using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedScript : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    int infectionRate = 0;

    [SerializeField]
    [Range(0, 100)]
    private int quarantineRespect = 0;

    [SerializeField]
    [Range(0, 100)]
    private int masks = 0;

    [SerializeField]
    [Range(0, 100)]
    private int washingHands = 0;

    [SerializeField] private GameObject sideMenu;
    [SerializeField] private String nameFoyer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color color = new Color();
        color = renderer.material.color;
        color.r = (float)infectionRate / 100;
        color.g = (100 - (float)infectionRate) / 100;
        renderer.material.color = color;
    }
    
    void OnMouseDown()
    {
        DisplaySideMenu();
    }

    public void DisplaySideMenu()
    {
        sideMenu.SetActive(!sideMenu.active);
        if (sideMenu.active)
        {
            this.tag = "SelectedFoyer";
        }
        else
        {
            this.tag = "FreeFoyer";
        }
    }

    public int getInfectionRate()
    {
        return this.infectionRate;
    }

    public void setInfectionRate ( int infectionRate)
    {
        this.infectionRate = infectionRate;
    }

    public int getQuarantineRespect()
    {
        return quarantineRespect;
    }

    public void setQuarantineRespect(int quarantineRespect)
    {
        this.quarantineRespect = quarantineRespect;
    }

    public int getMasks()
    {
        return masks;
    }

    public void setMasks(int masks)
    {
        this.masks = masks;
    }

    public int getWashingHands()
    {
        return washingHands;
    }

    public void setWashingHands(int washingHands)
    {
        this.washingHands = washingHands;
    }

    public string getNameFoyer()
    {
        return nameFoyer;
    }

    public void setNameFoyer(string nameFoyer)
    {
        this.nameFoyer = nameFoyer;
    }
}
