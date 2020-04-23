using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ChoiceManager : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnVirusSelection(GameObject virus)
    {
        Virus virusComponent = virus.GetComponent<Virus>();
        Debug.Log("click !" + virusComponent.name);
        Virus.SetActualVirus(virusComponent);
        SceneManager.LoadScene("CameraWork");
    }
}
