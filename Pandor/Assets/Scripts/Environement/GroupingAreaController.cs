using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupingAreaController : MonoBehaviour
{
    CharacterController ch;
    // Start is called before the first frame update

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ch = other.GetComponent<CharacterController>();
            ch.isArrived = true;
            Debug.Log("hELLO "+ ch.isArrived);

        }
    }
}
