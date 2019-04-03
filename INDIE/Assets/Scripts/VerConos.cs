using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerConos : MonoBehaviour {

    GameObject enemyGO;
    DynamicLight2D.DynamicLight light;

    // Si el cono de visión entra en el trigger se activa su renderer para que se vea el sprite
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<MovimientoEnemigo>())
        {
            light = other.gameObject.GetComponentInChildren<DynamicLight2D.DynamicLight>();
            light.Intensity = 0.75f;
            
        }
    }

    // Si sale se desactiva
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<MovimientoEnemigo>())
        {
            light = other.gameObject.GetComponentInChildren<DynamicLight2D.DynamicLight>();
            light.Intensity = 0.1f;
        }
    }
}
