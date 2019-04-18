using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirAnimación : MonoBehaviour {
    public GameObject animacionInicial;
    public GameObject animacionCaos;
    public GameObject player;
    bool primeraAnimacion;
    float horaPrimeraAnimacion;
    public float tiempoPrimeraAnimacion;
    bool segundaAnimacion;
    float horaSegundaAnimacion;
    public float tiempoSegundaAnimacion;
	// Use this for initialization
	void Start () {
        animacionInicial.gameObject.SetActive(true);
        primeraAnimacion = false;
        primeraAnimacion = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameManager.instance.CaosActual() == 100)
        {
            segundaAnimacion = true;
            horaSegundaAnimacion = Time.time;
            animacionCaos.gameObject.SetActive(true);
            
            
        }
        if(segundaAnimacion && Time.time < horaSegundaAnimacion + tiempoSegundaAnimacion)
        {
            Perder perder = player.GetComponent<Perder>();
            perder.enabled = false;
        }
	}
}
