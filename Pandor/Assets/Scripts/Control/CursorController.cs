﻿using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CursorController : MonoBehaviour
{
    [SerializeField] public GameObject inputField;


    [SerializeField] private GameObject menuInfected;
    [SerializeField] private GameObject tutoChoose;
    [SerializeField] private Text getText;

    Ray ray;
    RaycastHit hit;
    //CalculInfection calculInfection;
    public GameObject infectedHouse;
    private string nbInfected;
    private bool haveHome;
    private bool haveChooseNbInfected;
    private int number = 0;
    public int resultInfected = 0;

    private void Start()
    {
        //calculInfection = new CalculInfection();
        Time.timeScale = 0;
    }

    void Update()
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Input.GetButtonDown("Fire1"))
        {
            Debug.Log("clic");
            if (Physics.Raycast(ray, out hit))
            {
                Debug.Log("presque");

                if (hit.collider.name == "InfectIndicator"  && !haveHome)
                {
                    Debug.Log("ok");

                    infectedHouse = hit.collider.gameObject;
                    getText.text = "Veuillez choisir le taux d'infecté";
                    haveHome = true;
                    if (haveChooseNbInfected)
                    {
                        DisplayMenu();
                    }
                }
                
            }
        }
        
    }

    public void GetValueInput()
    {
        nbInfected = inputField.GetComponent<Text>().text;
        if (int.TryParse(nbInfected, out number))
        {
            haveChooseNbInfected = true;
            resultInfected = Int32.Parse(nbInfected);
            getText.text = "Veuillez choisir la zone d'infection";
            menuInfected.SetActive(false);
            if (haveHome)
            {
                Time.timeScale = 1;
                DisplayMenu();
                
            }
        }
    }

    public void DisplayMenu()
    {
        tutoChoose.SetActive(false);
    }

}
