using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoCompletado : MonoBehaviour {
    public string sonidoVictoria;
	
	
    void OnEnable()
    {
        GameManager.instance.ObjetivoCumplido();
        GameManager.instance.ReproducirSonido(sonidoVictoria);
        GameManager.instance.SubirPlanta();
        Destroy(this.gameObject);
    }

   
}
