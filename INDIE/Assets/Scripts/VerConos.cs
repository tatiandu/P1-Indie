using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerConos : MonoBehaviour {

    ConoDeVision conoScript;
    GameObject enemyGO;

    // Si el cono de visión entra en el trigger se activa su renderer para que se vea el sprite
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<MovimientoEnemigo>())
        {
            conoScript = other.gameObject.GetComponentInChildren<ConoDeVision>();
            conoScript.ActivarRender();
        }
    }

    // Si sale se desactiva
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<MovimientoEnemigo>())
        {
            conoScript = other.gameObject.GetComponentInChildren<ConoDeVision>();
            conoScript.DesactivarRender();
        }
    }
}
