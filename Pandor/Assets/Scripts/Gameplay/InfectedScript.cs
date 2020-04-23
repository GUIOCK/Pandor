﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfectedScript : MonoBehaviour
{
    [SerializeField]
    [Range(0, 100)]
    int infectionRate = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Renderer renderer = GetComponent<Renderer>();
        Color color = new Color();
        color = renderer.material.color;
        color.r = (float)infectionRate / 100;
        color.g = (100 - (float)infectionRate) / 100;
        renderer.material.color = color;
    }
}