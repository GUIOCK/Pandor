using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectionSiteMenuing : MonoBehaviour
{
    [SerializeField] private GameObject sideMenu;

    void OnMouseDown()
    {
        DisplaySideMenu();
    }

    public void DisplaySideMenu()
    {
        sideMenu.SetActive(!sideMenu.active);
    }


}
