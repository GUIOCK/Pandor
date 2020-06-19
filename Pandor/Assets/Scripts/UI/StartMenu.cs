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
    [SerializeField] private GameObject inGameCounter;
    [SerializeField] private GameObject endGame;

    private GameObject[] totalPeoples;
    private List<GameObject> infectedPeoples;
    private List<GameObject> districts = new List<GameObject>();
    private List<Dropdown.OptionData> districtsNames = new List<Dropdown.OptionData>();
    private District choosenDistrict;

    private Dropdown choiceDropdown;
    private InputField infectedNbInput;

    private int totalInfected;
    private int totalPeople;

    public void Start()
    {
        choiceDropdown = districtChoice.GetComponentInChildren<Dropdown>();

        infectedNbInput = districtChoice.GetComponentInChildren<InputField>();
        infectedPeoples = new List<GameObject>();
    }

    private void Update()
    {
        if(totalInfected == totalPeople && totalInfected != 0 && totalPeople != 0)
        {
            EndGame();
        }

        for(int i = 0 ; i < totalPeoples.Length; i++)
        {
            if (null != totalPeoples[i] && totalPeoples[i].GetComponent<People>().isInfected)
            {
                infectedPeoples.Add(totalPeoples[i]);
                totalPeoples[i] = null;
                totalInfected = infectedPeoples.Count;
                inGameCounter.GetComponentInChildren<Text>().text = "Infectés : " + totalInfected + " / " + totalPeople;
            }
        }
    }

    public void LaunchGame()
    {
        DisplayMenu();

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
        DisplayMenu();

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
        InGameCounter();
    }

    public void MainMenu()
    {
        DisplayMenu();
        mainMenu.SetActive(true);
    }

    

    public void AboutUs()
    {
        DisplayMenu();
        aboutUs.SetActive(true);
    }

    public void DisplayMenu()
    {
        foreach (Transform menu in transform)
        {
            menu.gameObject.SetActive(false);
        }
    }

    public void InGameCounter()
    {
        DisplayMenu();
        totalPeoples = GameObject.FindGameObjectsWithTag("Player");
        totalPeople = totalPeoples.Length;
        inGameCounter.GetComponentInChildren<Text>().text = "Infectés : " + totalInfected + " / " + totalPeople;
        inGameCounter.SetActive(true);

    }

    public void EndGame()
    {
        DisplayMenu();
        endGame.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
