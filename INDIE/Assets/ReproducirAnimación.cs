using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirAnimación : MonoBehaviour {

    public GameObject animacion;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.CaosActual() == 100)
        {
            animacion.SetActive(true);
        }
	}
}
