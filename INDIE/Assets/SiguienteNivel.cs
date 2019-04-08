using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiguienteNivel : MonoBehaviour {

    public int sigEscena;
	void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Player" && GameManager.instance.HasGanado())
        {
            GameManager.instance.SaltarEscena(sigEscena);
        }
    }
}
