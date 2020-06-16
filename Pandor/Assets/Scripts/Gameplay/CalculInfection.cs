using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculInfection : MonoBehaviour
{
    InfectedScript infectedScript;

    int maxIncrementValue = 10;

    int tauxPortMasque = 0;         // Var paramètres foyer à récup
    int tauxUtilGel = 0;            //
    int tauxConfinement = 0;        //
    float index = 0;

    private int risqueAvecMasque = 16;
    private int risqueAvecGel = 14;
    private int risqueAvecConfinement = 1;

    private int risqueSansMasque = 95;
    private int risqueSansGel = 95;
    private int risqueSansConfinement = 95;

    private int risqueTotal = 0;        // Pourcentage

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("okido");
        infectedScript = GetComponentInChildren<InfectedScript>();
    }

    // Update is called once per frame
    void Update()
    {
        index += Time.deltaTime;
        if (index >= 2)
        {
            risqueTotal = Increment();
            index = 0;
        }
    }

    public int Increment()
    {
        //Debug.Log("pouet" + infectedScript.getMasks());
        int risqueTotal;

        risqueTotal = ((risqueAvecMasque * (infectedScript.getMasks() / 100)) + (risqueSansMasque * (1 - (infectedScript.getMasks() / 100))) + (risqueAvecGel * (infectedScript.getWashingHands() / 100)) + (risqueSansGel * (1 - (infectedScript.getWashingHands() / 100))) + (risqueAvecConfinement * (infectedScript.getQuarantineRespect() / 100)) + (risqueSansConfinement * (1 - (infectedScript.getQuarantineRespect() / 100)))) / 3;
        //Debug.Log("Risque total : " + risqueTotal + "%");
        maxIncrementValue = risqueTotal; // La vitesse d'augmentation maximale correspond au risque d'atrapper le virus (ex : si 100% de risque, 100% du foyer va finir contaminé très rapidement)

        infectedScript.infectionRate += Random.Range(0, maxIncrementValue);
        if (infectedScript.infectionRate > 100)
        {
            infectedScript.infectionRate = 100;
        }
        //Invoke("Increment", 10f);
        return risqueTotal;
    }

    
}