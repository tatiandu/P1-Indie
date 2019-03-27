﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamaraSeguridad : MonoBehaviour {
    public float velocidad;
    Vector3 rotacionInicial;
    float rotacionBase;

    
    void Start ()
    {
        InvokeRepeating("CambioSentido", 1, 2);
    }
	
	
	void Update ()
    {
        transform.Rotate(new Vector3(0, 0, velocidad * Time.deltaTime));
    }

    void CambioSentido()
    {
        velocidad = -velocidad;
    }
}
