using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.EventSystems;
using System.IO;

public class Menuprincipal : MonoBehaviour
{
    public GameObject botonesPrincipales, niveles, ajustes, continuar, fondo, fondoNiveles;
    public AudioMixer audioMixer;
    public GameObject nivel1, nivel2, nivel3;
    int numeroNiveles;

    void Start()
    {
        
        if (!File.Exists("partida.txt"))     //Si no existe continuar no debe salir y activo el nivel 1
        {
            numeroNiveles = 1;
            continuar.SetActive(false);
            nivel1.SetActive(true);
            StreamWriter archivo = new StreamWriter("partida.txt");  //Creo el archivo y pongo el nivel 1 pero sin activar el "continuar"
            archivo.WriteLine("1");
            archivo.WriteLine("Total " + numeroNiveles);
            archivo.Close();
        }
        else
        {
            StreamReader cargar = new StreamReader("partida.txt");  // si existe leo la primera linea para ver cuántos niveles tengo que mostrar
            //Leemos la escena que debemos cargar
            string[] lectura = new string[1];
            while (lectura[0] != "Total")
            {
                lectura = cargar.ReadLine().Split(' ');

            }
            numeroNiveles = int.Parse(lectura[1]);
            print(numeroNiveles);
            cargar.Close();
           
        }
        switch (numeroNiveles)
        {
            case 1:
                nivel1.SetActive(true);

                break;
            case 2:
                nivel1.SetActive(true);
                nivel2.SetActive(true);
                break;
            case 3:
                nivel1.SetActive(true);
                nivel2.SetActive(true);
                nivel3.SetActive(true);
                break;
        }
    }




    public void CargarNivel(int escena)
    {
        GameManager.instance.ActualizarEscena(escena);
        GameManager.instance.CargarEscena(escena);
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
    public void Continuar()
    {
        GameManager.instance.CargarPartida();
    }


}
