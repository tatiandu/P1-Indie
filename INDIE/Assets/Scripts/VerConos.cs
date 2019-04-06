using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerConos : MonoBehaviour {

    Transform cono;

    // Si el cono de visión entra en el trigger se activa su renderer para que se vea el sprite
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.GetComponent<MovimientoEnemigo>())
        {
            cono = other.transform.GetChild(1);
            cono.gameObject.SetActive(true);
        }
    }

    // Si sale se desactiva
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<MovimientoEnemigo>())
        {
            cono = other.transform.GetChild(1);
            cono.gameObject.SetActive(false);
        }
    }
}
