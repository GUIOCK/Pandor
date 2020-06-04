using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupingAreaController : MonoBehaviour
{
    CharacterController ch;
    // Start is called before the first frame update
    void Start()
    {
        //ch = new CharacterController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            CharacterController ch = other.gameObject.GetComponent<CharacterController>();
            ch.isArrived = true;
            Debug.Log("hELLO");

        }
    }
}
