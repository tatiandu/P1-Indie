using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZonaClave : MonoBehaviour {

    public GameObject enemy;

	void Start ()
    {
        Physics2D.queriesHitTriggers = false;               // Para que el raycast no detecte a este trigger
    }

    // Si el enemigo se sale del trigger deja de perseguir al jugador
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("abandono");
            enemy.GetComponent<MovimientoEnemigo>().AbandonoZona();
        }
    }
}
