﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleLayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
                gameObject.GetComponent<Renderer>().sortingOrder = 5;
    }
}
