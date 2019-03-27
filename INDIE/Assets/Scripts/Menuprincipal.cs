using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Menuprincipal : MonoBehaviour {
    public GameObject botonesPrincipales;
    public GameObject niveles;
    public GameObject ajustes;
    public AudioMixer audioMixer;

    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}



    public void CargarNivel(int escena)
    {
        GameManager.instance.CargarEscena(escena);
        GameManager.instance.ActualizarEscena(escena);
    }
    public void SelecciónNiveles()
    {
        botonesPrincipales.SetActive(false);
        niveles.SetActive(true);
    }
    public void VolverMenu()
    {
        niveles.SetActive(false);
        ajustes.SetActive(false);
        botonesPrincipales.SetActive(true);
        
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
     
}
