using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    float volumen;
    float Caos, maxCaos;
    bool subirAscensor;
    Disfraz disfrazActual;
    UIManager uIManager;
    AudioManager audioManager;
    int coleccionables;
    //Al pasar de escena se debe sumar 1 a esta variable
    int CurrentScene = 1;

    //Discutir solución
    MoveEnemy Lead;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        disfrazActual = Disfraz.ninguno;
        volumen = 0.5f;
    }

    private void Start()
    {
        Caos = 0;
        maxCaos = 100;
        subirAscensor = false;
        coleccionables = 0;
    }

    void Update()
    {
        //Debug.Log(disfrazActual);
        if (Input.GetButtonDown("Pause"))
        {
            uIManager.Pausar();
            
        }
    }
    //Es llamado al comienzo de la escena por el AudioManager
    public void AvisoAudioManager(AudioManager audio)
    {
        audioManager = audio;
    }

    //Es llamado al principio de la escena por el UIManager para que sepamos de su existencia
    public void AvisoUI(UIManager UI)
    {
        uIManager = UI;
    }

    //Es llamado al principio de la escena por el Lead para que sepamos de su existencia
    public void AvisoLead(MoveEnemy lead)
    {
        Lead = lead;
    }

    //Llega una nueva cantidad de caos generado, guardamos el valor actual lo mandamos al UIManager para que lo muestre
    public void GenerarCaos(float nuevocaosgenerado)
    {
        Caos = Caos + nuevocaosgenerado;
        uIManager.AumentaCaos(Caos);
        //AJ
        if (Caos >= maxCaos)
        {
            Lead.enabled = true;
        }
    }

    //Avisa al gamemanager del estado de la interacción
    public void Interactuando(float tiempoInteraccion, bool interaccion)
    {
        uIManager.Interactuando(tiempoInteraccion, interaccion);
    }

    //Le llegá el nuevo disfraz del jugador, se lo guarda y avisa al Uimanager para que cambie los iconos
    public void CambioDisfrazJugador(Disfraz jugador)
    {
        disfrazActual = jugador;
        uIManager.Detección(disfrazActual);
    }
    //Muestra el trazo, resalta la palabra interactuar y muestra una descripción de lo que hace el objeto
    public void EsInteractuable(bool activarODesactivar, string descripción)
    {
        uIManager.EsInteractuable(activarODesactivar, descripción);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(CurrentScene);
        Caos = 0;
        subirAscensor = false;
    }

    public Disfraz DisfrazJugador()   //Le da al jugador su disfraz actual. Útil para cuando cambias de escena y el jugador ya tenia un disfraz, el GameManager lo guarda entre escenas
    {
        return disfrazActual;
    }

    public float CaosActual()
    {
        return Caos;
    }

    public void ReproducirSonido(string nombreSonido)
    {
        audioManager.Play(nombreSonido);
        Debug.Log(nombreSonido);
    }

    /*Hay que avisar al UI de que muestre el panel de objetivo cumplido*/
    public void ObjetivoCumplido()
    {
        uIManager.ObjetivoCumplido();
    }

    public void Perder()
    {
        uIManager.Perder();
    }

    public void CargarEscena(int escenaBuild)
    {
        SceneManager.LoadScene(escenaBuild);
    }
    public void ActualizarEscena(int escena)
    {
        CurrentScene = escena;
        Caos = 0;
    }
    public void SubirPlanta()
    {
        subirAscensor = !subirAscensor;
    }
    public bool HasGanado()
    {
        return subirAscensor;
    }
    public void MenuGanar()
    {
        uIManager.FinDemo();
        ReproducirSonido("Ascensor");
        subirAscensor = false;
    }
    public void AjustarVolumen(float vol)
    {
        volumen = vol;
    }
    public float DameVolumen()
    {
        return volumen;
    }

    public void ColeccionableRecogido()
    {
        coleccionables++;
        uIManager.ColeccionableRecogido(coleccionables);
    }
    public void SigNivel()
    {
        CurrentScene++;
        CargarEscena(CurrentScene);
        
    }
    public void ReproducirPitchAleatorio(string sonido)
    {

        audioManager.PlayRandomPitch(sonido);
    }
}
