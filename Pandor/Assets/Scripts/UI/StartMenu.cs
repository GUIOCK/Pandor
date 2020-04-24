using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private string sceneGame = "VirusSelectionMenu";
    [SerializeField] private GameObject aboutUs;
    [SerializeField] private GameObject tutorial;
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject loading;
    public void LaunchGame()
    {
        DiplayMenu();
        loading.SetActive(true);
        SceneManager.LoadScene(sceneGame);

    }

    public void MainMenu()
    {
        DiplayMenu();
        mainMenu.SetActive(true);
    }

    public void Tutorial()
    {
        DiplayMenu();
        tutorial.SetActive(true);
    }

    public void AboutUs()
    {
        DiplayMenu();
        aboutUs.SetActive(true);
    }

    public void DiplayMenu()
    {
        foreach(Transform menu in transform)
        {
            menu.gameObject.SetActive(false);
            
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
