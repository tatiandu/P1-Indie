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
    bool saltadaPrimeraAnimacion;
    bool saltadaSegundaAnimacion;
    float horaSegundaAnimacion;
    public float tiempoSegundaAnimacion;
    public float tiempoInvulnerabilidad;
    public float alpha;
    // Use this for initialization
    void Start()
    {
        saltadaPrimeraAnimacion = false;
        saltadaSegundaAnimacion = false;
        if (GameManager.instance.ReproducirAnimacionPrincipio() ==true)
        {
            Color tmp = player.GetComponent<SpriteRenderer>().color;
            tmp.a = alpha;
            player.GetComponent<SpriteRenderer>().color = tmp;
            animacionInicial.gameObject.SetActive(true);
            primeraAnimacion = true;
            horaPrimeraAnimacion = Time.time;
            segundaAnimacion = false;
            player.GetComponent<Perder>().enabled = false;
            player.GetComponent<movimiento>().enabled = false;
        }
        else
        {            
            primeraAnimacion = true;
            horaPrimeraAnimacion = Time.time;
            segundaAnimacion = false;
           
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!saltadaPrimeraAnimacion && primeraAnimacion && Time.time < horaPrimeraAnimacion + tiempoPrimeraAnimacion && animacionInicial.activeSelf && (Mathf.Abs(Input.GetAxis("Vertical"))>0 || Mathf.Abs(Input.GetAxis("Horizontal"))>0))  //en caso de saltarte la primera animacion
        {
            saltadaPrimeraAnimacion = true;
            animacionInicial.SetActive(false);
            Color tmp = player.GetComponent<SpriteRenderer>().color;
            tmp.a = alpha;
            player.GetComponent<SpriteRenderer>().color = tmp;
            //player.GetComponent<Perder>().enabled = true;
            player.GetComponent<movimiento>().enabled = true;
            Invoke("TiempoInvulnerabilidad", tiempoInvulnerabilidad);
        }
        if (GameManager.instance.CaosActual() >= 100 && !segundaAnimacion)   //activacion de la animacion del caos
        {
            Color tmpCaos = player.GetComponent<SpriteRenderer>().color;
            tmpCaos.a = 0.5f;
            player.GetComponent<SpriteRenderer>().color = tmpCaos;
            segundaAnimacion = true;
            horaSegundaAnimacion = Time.time;
            animacionCaos.gameObject.SetActive(true);
            player.GetComponent<Perder>().enabled = false;
            player.GetComponent<movimiento>().enabled = false;
            GameManager.instance.MostrarTextoEnPantalla(4f, "Coje la tarjeta y vuelve al ascensor para subir al siguiente piso");
        }
        if (!saltadaPrimeraAnimacion && primeraAnimacion && !segundaAnimacion && Time.time > horaPrimeraAnimacion + tiempoPrimeraAnimacion)   //en caso de que no te hayas saltado la primera animacion
        {
            //player.GetComponent<Perder>().enabled = true;
            player.GetComponent<movimiento>().enabled = true;
            Invoke("TiempoInvulnerabilidad", tiempoInvulnerabilidad);
        }
        if (!saltadaSegundaAnimacion && segundaAnimacion && Time.time < horaSegundaAnimacion + tiempoSegundaAnimacion && animacionCaos.activeSelf && (Mathf.Abs(Input.GetAxis("Vertical")) > 0 || Mathf.Abs(Input.GetAxis("Horizontal")) > 0))
        {
            saltadaSegundaAnimacion = true;
            animacionCaos.SetActive(false);
            Color tmp = player.GetComponent<SpriteRenderer>().color;
            tmp.a = alpha;
            player.GetComponent<SpriteRenderer>().color = tmp;
            //player.GetComponent<Perder>().enabled = true;
            player.GetComponent<movimiento>().enabled = true;
            Invoke("TiempoInvulnerabilidad", tiempoInvulnerabilidad);
        }
            if (!saltadaSegundaAnimacion && segundaAnimacion && Time.time > horaSegundaAnimacion + tiempoSegundaAnimacion/* && Input.GetKey(KeyCode.W)*/)    //en caso de que no te hayas saltado la segunda animacion
        {
           //player.GetComponent<Perder>().enabled = true;
            player.GetComponent<movimiento>().enabled = true;
            Invoke("TiempoInvulnerabilidad", tiempoInvulnerabilidad);
        }

    }

    public void TiempoInvulnerabilidad()
    {
        player.GetComponent<Perder>().enabled = true;
        Color tmp = player.GetComponent<SpriteRenderer>().color;
        tmp.a = 1;
        player.GetComponent<SpriteRenderer>().color = tmp;

    }
}
