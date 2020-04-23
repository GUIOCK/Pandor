using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Virus : MonoBehaviour
{
    // Start is called before the first frame update
    public string virusName;
    [Range(0,100)]
    public float tauxPropagation;
    [Range(0,100)]
    public float tauxMortalite;
    static public Virus actualVirus;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void SetActualVirus(Virus virus)
    {
        Debug.Log("Le virus selectionné était : " + actualVirus);
        actualVirus = virus;
        Debug.Log(", il a été changé en : " + actualVirus);
    }
}
