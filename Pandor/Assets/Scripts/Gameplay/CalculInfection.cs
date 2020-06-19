using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculInfection : MonoBehaviour
{
    InfectedScript infectedScript;

    float maxIncrementValue = 10;

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

    private float risqueTotal = 0;        // Pourcentage

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

    public float Increment()
    {
        //Debug.Log("pouet" + infectedScript.getMasks());
        float risqueTotal;

        risqueTotal = ((risqueAvecMasque * (infectedScript.getMasks() / 1000)) + (risqueSansMasque * (1 - (infectedScript.getMasks() / 1000))) + (risqueAvecGel * (infectedScript.getWashingHands() / 1000)) + (risqueSansGel * (1 - (infectedScript.getWashingHands() / 1000))) + (risqueAvecConfinement * (infectedScript.getQuarantineRespect() / 1000)) + (risqueSansConfinement * (1 - (infectedScript.getQuarantineRespect() / 1000)))) / 30;
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