using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using System.IO;

public class Menuprincipal : MonoBehaviour {
    public GameObject botonesPrincipales, niveles, ajustes, continuar, fondo, fondoNiveles;
    public AudioMixer audioMixer;

    void Start () {
        if (!File.Exists("partida.txt"))
        {
            continuar.SetActive(false);
        }
    }
	
	


    public void CargarNivel(int escena)
    {
        GameManager.instance.ActualizarEscena(escena);
        GameManager.instance.CargarEscena(escena);
        switch (escena)
        {
            case 1:
                GameManager.instance.CambioDisfrazJugador(Disfraz.ninguno);
                break;
            case 2:
                GameManager.instance.CambioDisfrazJugador(Disfraz.programador);
                break;
            case 3:
                GameManager.instance.CambioDisfrazJugador(Disfraz.ninguno);
                break;
        }
        
    }
    public void SelecciónNiveles()
    {
        botonesPrincipales.SetActive(false);
        niveles.SetActive(true);

        fondo.SetActive(false);
        fondoNiveles.SetActive(true);
        
    }
    public void VolverMenu()
    {
        niveles.SetActive(false);
        ajustes.SetActive(false);
        botonesPrincipales.SetActive(true);
        fondo.SetActive(true);
        fondoNiveles.SetActive(false);


    }
    public void SalirJuego()
    {
        Application.Quit();   // funcionara cuando tengamos el juego como una aplicacion de escritorio, mientras desarrollemos no
    }
    public void Opciones()
    {
        botonesPrincipales.SetActive(false);
        ajustes.SetActive(true);
    }
    public void AjustarVolumen(float volumen)
    {
        //audioMixer.SetFloat("volumen", volumen);
        Debug.Log(volumen);
        GameManager.instance.AjustarVolumen(volumen);
    }
    public void PantallaCompleta(bool pantallaCompleta)
    {
        Screen.fullScreen = pantallaCompleta;
    }
     public void Continuar()
    {
        GameManager.instance.CargarPartida();
    }

    public EventSystem eventSystem;
    public GameObject selectedObject;

    bool buttonSelected;



    void Update()
    {
        //si se acciona el eje vertical y no hay ningún botón seleccionado selecciona el primer botón 
        if (Input.GetAxisRaw("Vertical") != 0 && !buttonSelected)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;

        }
        else if (Input.GetAxisRaw("Horizontal") != 0 && !buttonSelected)
        {
            eventSystem.SetSelectedGameObject(selectedObject);
            buttonSelected = true;

        }
    }
    //al desactivarse el botón está de nuevo disponible
    void OnDisable()
    {

        buttonSelected = false;
    }

    private void OnEnable()
    {
        eventSystem.SetSelectedGameObject(null);
    }
}
