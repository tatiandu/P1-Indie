﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public GameObject menuPerder;
    public GameObject Pause;
    public GameObject finDemo;
    public Image[] RolesPausa;
    int tarjetasAdquiridas = 2;//debería ir en el GM
    public Image Caos, fondoCaos, camara, artistas, diseñadores, programadores, personal, barraInteraccion;
    public GameObject interaccion;
    public GameObject recuadroInstrucciones;
    public Text coleccionables;
 
    public GameObject objetivoCumplido;
    bool visualizarcaos = false;
    bool interactuando = false;
    bool objetivoCompletado = false;
    float vicaos,viObjetivoCumplido;
    public float tiempovistacaos;
    //AJ
    public Text Interactuar, Descripcion;
    //FinAJ
    float maxInteraccion, procesoInteraccion;

    /*Pongo invisibles paneles que solo se verán en determinados momentos y aviso al GameManager de mi existencia*/
    private void Start()
    {
        recuadroInstrucciones.SetActive(true);
        GameManager.instance.AvisoUI(this.gameObject.GetComponent<UIManager>());
        //objetivoCumplido.SetActive(false);
        Caos.enabled = false;
        fondoCaos.enabled = false;
    }

    /*Este método activa y desactiva los iconoc de aquellos npcs que te detectan t de los que no, lo hace teniendo en cuenta el disfraz que le llega como parámetro*/
    public void Detección(Disfraz disfrazActual)
    {
        if (disfrazActual == Disfraz.ninguno)
        {
            camara.enabled = true;
            artistas.enabled = true;
            diseñadores.enabled = true;
            programadores.enabled = true;
            personal.enabled = true;
        }
        else if (disfrazActual == Disfraz.programador)
        {
            camara.enabled = true;
            artistas.enabled = false;
            diseñadores.enabled = true;
            programadores.enabled = true;
            personal.enabled = true;
        }
        else if (disfrazActual == Disfraz.artista)
        {
            camara.enabled = true;
            artistas.enabled = true;
            diseñadores.enabled = true;
            programadores.enabled = false;
            personal.enabled = true;
        }
        else if (disfrazActual == Disfraz.diseñador)
        {
            camara.enabled = true;
            artistas.enabled = true;
            diseñadores.enabled = true;
            programadores.enabled = false;
            personal.enabled = true;
        }
        else if (disfrazActual == Disfraz.personal)
        {
            camara.enabled = false;
            artistas.enabled = false;
            diseñadores.enabled = false;
            programadores.enabled = false;
            personal.enabled = true;
        }
    }
    private void Update()
    {
        if (interactuando) //Si se interactúa la barra aumenta lo necesario para llegar al 100% en el tiempo de interaccion maximo
        {
            procesoInteraccion += (1 / maxInteraccion) * Time.deltaTime;
            barraInteraccion.fillAmount = procesoInteraccion;
        }
        if (visualizarcaos && (vicaos + tiempovistacaos) < Time.time)  // si es true que hay que ver el caos pero ya se ha visualizado "X" segundos verlo pasa a ser false y escondemos la barra
        {
            visualizarcaos = false;
            Caos.enabled = false;
            fondoCaos.enabled = false;

        }
        if (objetivoCompletado && viObjetivoCumplido + tiempovistacaos < Time.time)  //si es true pero ya han pasado X segundos significa a que ya no hará falta ver más el panel de "Has completado el objetivo, vuelve al ascensor"
        {
            objetivoCompletado = false;
            objetivoCumplido.SetActive(false);
        }
    }

    public void Interactuando(float tiempoInteraccion, bool interaccion)
    {
        interactuando = interaccion;
        maxInteraccion = tiempoInteraccion;
        if (!interaccion) NoInteractuando();
    }

    public void NoInteractuando() //Si no se interactua se resetea
    {
        barraInteraccion.fillAmount = 0;
        procesoInteraccion = 0;
    }

    /*Le llega la cantidad exacta de caos que hay en el nivel y muestra la barra con la longitud específica*/
    public void AumentaCaos(float valorCaos)
    {
        visualizarcaos = true;
        Caos.enabled = true;
        fondoCaos.enabled = true;

        Caos.fillAmount = valorCaos / 100;
        vicaos = Time.time;
    }

    //AJ
    public void EsInteractuable(bool activarODesactivar, string descripción)
    {
        if (activarODesactivar)
        {
            Interactuar.color = new Color(0.840034f, 0.9528302f, 0.3011303f, 0.9215686f);
            Descripcion.text = descripción;
        }
        else
        {
            Interactuar.color = Color.grey;
            Descripcion.text = " ";
        }
    }

    public void Pausar()
    {//se paran el tiempo, se activa el menú de pausa y se activan los disfraces que tiene el jugador
        Time.timeScale = 0;
        Pause.SetActive(true);
        for (int i = 0; i < tarjetasAdquiridas; i++)
        {
            RolesPausa[i].gameObject.SetActive(true);
        }
    }
    public void Perder()
    {
        Time.timeScale = 0;
        menuPerder.SetActive(true);
    }
    public void FinPerder()
    {
        Time.timeScale = 1;
        menuPerder.SetActive(false);
        GameManager.instance.ResetScene();
    }

    public void FinPausa()
    {
        Time.timeScale = 1;
        Debug.Log("finpausa");
        Pause.SetActive(false);
        for (int i = 0; i < tarjetasAdquiridas; i++)
        {
            RolesPausa[i].gameObject.SetActive(false);
        }
    }
    //FinAJ
    /*Muestra un panel que indica que se ha completado el objetivo del nivel, comportamiento identico al de la visualización del caos*/
    public void ObjetivoCumplido()
    {
        objetivoCompletado = true;
        viObjetivoCumplido = Time.time;
        objetivoCumplido.SetActive(true);
    }
    public void Cambiaescena(int escena) {
        GameManager.instance.ActualizarEscena(escena);
        GameManager.instance.CargarEscena(escena);
        Time.timeScale = 1;
    }
    public void FinDemo()
    {
        finDemo.SetActive(true);
        Time.timeScale = 0;
    }

    public void ColeccionableRecogido(int n)
    {
        coleccionables.text = "X " + n;
    }
    public void SigNivel()
    {
        GameManager.instance.SigNivel();
    }
}