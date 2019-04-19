using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproducirAnimación : MonoBehaviour
{
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
    void Start()
    {
        animacionInicial.gameObject.SetActive(true);
        primeraAnimacion = true;
        horaPrimeraAnimacion = Time.time;
        segundaAnimacion = false;
        player.GetComponent<Perder>().enabled = false;
        player.GetComponent<movimiento>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.CaosActual() == 100 && !segundaAnimacion)
        {
            segundaAnimacion = true;
            horaSegundaAnimacion = Time.time;
            animacionCaos.gameObject.SetActive(true);
            player.GetComponent<Perder>().enabled = false;
            player.GetComponent<movimiento>().enabled = false;



        }
        if (primeraAnimacion && !segundaAnimacion && Time.time > horaPrimeraAnimacion + tiempoPrimeraAnimacion)
        {
            player.GetComponent<Perder>().enabled = true;
            player.GetComponent<movimiento>().enabled = true;
        }
        if (segundaAnimacion && Time.time > horaSegundaAnimacion + tiempoSegundaAnimacion/* && Input.GetKey(KeyCode.W)*/)
        {
            player.GetComponent<Perder>().enabled = true;
            player.GetComponent<movimiento>().enabled = true;
        }

    }
}
