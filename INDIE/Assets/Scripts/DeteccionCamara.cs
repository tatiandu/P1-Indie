using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeteccionCamara : MonoBehaviour {

    public GameObject sombra;
    public GameObject enemigo;
    public Transform[]rutaPatrulla;
    MovimientoEnemigo movEnemy;

    void Start () {
        movEnemy = enemigo.GetComponent<MovimientoEnemigo>();
        enemigo.SetActive(false);
	}
	
	void Update () {
		if(enemigo && movEnemy.Hellegado())
        {
            GuardarVuelta(rutaPatrulla);
            movEnemy.CambioPatron(rutaPatrulla);
        }        
        ComprobarNoNull(rutaPatrulla);        
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        RaycastHit2D ray = Physics2D.Raycast(transform.position, other.transform.position - transform.position);

        if (other.tag == "Player" && ray.transform.tag == "Player")
        {
            GameObject poolSombras = GameObject.Find("SombrasPool");
            GameObject silueta = Instantiate<GameObject>(sombra, other.transform.position, other.transform.rotation,poolSombras.transform);                      
            rutaPatrulla[rutaPatrulla.Length - 1] = silueta.transform;
            if (!enemigo.activeSelf)
            {
                enemigo.SetActive(true);
                movEnemy.CambioPatron(rutaPatrulla);
            }
        }
    }
    public void GuardarVuelta(Transform[] enemigo)
    {
        rutaPatrulla = enemigo;
        for (int i = 0; i < rutaPatrulla.Length / 2; i++)
        {
            Swap(ref rutaPatrulla[i], ref rutaPatrulla[rutaPatrulla.Length - i - 1]);
        }
    }

    void Swap(ref Transform a, ref Transform b)
    {
        Transform temp = b;
        b = a;
        a = temp;
    }

    public void ComprobarNoNull(Transform[] rutaPatrulla)
    {
        if (rutaPatrulla[0] == null)
        {
            rutaPatrulla[0] = rutaPatrulla[1];
        }
        else if (rutaPatrulla[rutaPatrulla.Length - 1]==null)
        {
            rutaPatrulla[rutaPatrulla.Length - 1] = rutaPatrulla[rutaPatrulla.Length - 2];
        }
    }
}
