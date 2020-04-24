using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SideMenu : MonoBehaviour
{
    private InfectedScript foyer;

    private int washingHands;
    private int quarantineRespect;
    private int masks;
    private string nameFoyer;

    private Text tauxQuarantineRespect;
    private Text tauxWashingHands;
    private Text tauxMasks;
    private Text libelleNameFoyer;
    private Slider sliderQuarantineRespect;
    private Slider sliderWashingHands;
    private Slider sliderMasks;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("SelectedFoyer") != null || GameObject.FindGameObjectsWithTag("SelectedFoyer").Length != 0)
        {
            foyer = (InfectedScript)GameObject.FindGameObjectsWithTag("SelectedFoyer")[0].GetComponent("InfectedScript");
            washingHands = foyer.getWashingHands();
            quarantineRespect = foyer.getQuarantineRespect();
            masks = foyer.getMasks();
            nameFoyer = foyer.getNameFoyer();

            libelleNameFoyer = this.transform.GetChild(0).GetComponentInChildren<Text>();
            tauxQuarantineRespect = this.transform.GetChild(1).GetComponentInChildren<Text>();
            tauxMasks = this.transform.GetChild(2).GetComponentInChildren<Text>();
            tauxWashingHands = this.transform.GetChild(3).GetComponentInChildren<Text>();
            sliderQuarantineRespect = this.transform.GetChild(4).GetComponentInChildren<Slider>();
            sliderMasks = this.transform.GetChild(5).GetComponentInChildren<Slider>();
            sliderWashingHands = this.transform.GetChild(6).GetComponentInChildren<Slider>();

            libelleNameFoyer.text = nameFoyer;
            tauxQuarantineRespect.text = quarantineRespect.ToString();
            tauxWashingHands.text = washingHands.ToString();
            tauxMasks.text = masks.ToString();

            sliderQuarantineRespect.value = quarantineRespect / 100f;
            sliderWashingHands.value = washingHands / 100f;
            sliderMasks.value = masks / 100f;
        }
    }

}
