using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour
{
    private string sceneGame = "VirusSelectionMenu";
    [SerializeField] private GameObject aboutUs;
    [SerializeField] private GameObject districtChoice;
    [SerializeField] private GameObject mainMenu;
    private List<GameObject> districts = new List<GameObject>();
    private List<Dropdown.OptionData> districtsNames = new List<Dropdown.OptionData>();
    private District choosenDistrict;

    private Dropdown choiceDropdown;
    private InputField infectedNbInput;

    public void Start()
    {
        choiceDropdown = districtChoice.GetComponentInChildren<Dropdown>();

        infectedNbInput = districtChoice.GetComponentInChildren<InputField>();
    }

    public void LaunchGame()
    {
        DiplayMenu();

        for (int i = 0; i < transform.parent.transform.childCount; i++)
        {
            if (transform.parent.transform.GetChild(i).GetComponent<District>())
            {
                districts.Add(transform.parent.transform.GetChild(i).gameObject);
            }
        }

        foreach (GameObject district in districts)
        {
            districtsNames.Add(new Dropdown.OptionData() { text = district.GetComponent<District>().DistrictName });
        }

        choiceDropdown.AddOptions(districtsNames);
        districtChoice.SetActive(true);
    }

    public void DistrictChoice()
    {
        DiplayMenu();

        choosenDistrict = GameObject.Find(choiceDropdown.options[choiceDropdown.value].text).GetComponent<District>();
        foreach(GameObject district in districts)
        {
            if (choosenDistrict.DistrictName.Equals(district.GetComponent<District>().DistrictName))
            {
                district.GetComponent<District>().StartGame(int.Parse(infectedNbInput.text));
            }
            else
            {
                district.GetComponent<District>().StartGame(0);
            }
        }
        
    }

    public void MainMenu()
    {
        DiplayMenu();
        mainMenu.SetActive(true);
    }

    

    public void AboutUs()
    {
        DiplayMenu();
        aboutUs.SetActive(true);
    }

    public void DiplayMenu()
    {
        foreach (Transform menu in transform)
        {
            menu.gameObject.SetActive(false);
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
