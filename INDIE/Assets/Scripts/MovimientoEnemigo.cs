using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoEnemigo : MonoBehaviour {

    public int velocidadEstandar, velocidadPersecucion;
    public Transform[] puntosPatrulla;
    public GameObject playerGO, exclamationPrefab;
    GameObject exclamationSprite;
    int i;
    Rigidbody2D rb;
    Vector2 direccion, direccionInicial;
    RaycastHit2D ray;
   public  Estados estado;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        estado = Estados.volviendo;
        direccionInicial = transform.right;
        i = 0;
        Physics2D.queriesStartInColliders = false;
    }
	
	void Update () {
		
        switch (estado)     //Maquina de estados
        {
            case Estados.patrulla:
                EstadoPatrulla();
                break;
            case Estados.persecucion:
                EstadoPersecucion();
                break;
            case Estados.volviendo:
                EstadoVolviendo();
                break;
        }
	}

    void EstadoPatrulla()
    {
        if (puntosPatrulla.Length > 1)      //Si el NPC va a seguir un patron
        {
            if (Vector2.Distance(puntosPatrulla[i % puntosPatrulla.Length].position, transform.position) > 0.4f)     //Movimiento hasta llegar al siguiente punto
            {
                direccion = new Vector2(puntosPatrulla[i % puntosPatrulla.Length].position.x - transform.position.x, puntosPatrulla[i % puntosPatrulla.Length].position.y - transform.position.y).normalized;
                transform.right = direccion;
                rb.velocity = transform.right * velocidadEstandar;
            }
            else i++;
        }
        else
        {
            transform.right = direccionInicial;     //Se queda mirando a la posicion inicial
            rb.velocity = Vector2.zero;
        }
    }

    void EstadoPersecucion()
    {
        ray = Physics2D.Raycast(transform.position, playerGO.transform.position - transform.position, Vector2.Distance(playerGO.transform.position, transform.position));  //Raycast
        Debug.DrawRay(transform.position, playerGO.transform.position - transform.position, Color.red);    //Debug del raycast

        if (ray.transform.tag == "Player")      //Si el tag es player le persigue
        {
            if (exclamationSprite == null) exclamationSprite = Instantiate<GameObject>(exclamationPrefab);
            direccion = new Vector2(playerGO.transform.position.x - transform.position.x, playerGO.transform.position.y - transform.position.y).normalized;
            transform.right = direccion;
            rb.velocity = transform.right * velocidadEstandar;
        }
        else CambiaEstado(Estados.volviendo);

        if (exclamationSprite != null)  exclamationSprite.transform.position = transform.position + new Vector3(0f, 2f, 0f);
    }

    void EstadoVolviendo()
    {
        ray = Physics2D.Raycast(transform.position, puntosPatrulla[i % puntosPatrulla.Length].transform.position - transform.position, Vector2.Distance(puntosPatrulla[i % puntosPatrulla.Length].transform.position, transform.position)); //Raycast
        Debug.DrawRay(transform.position, puntosPatrulla[i % puntosPatrulla.Length].transform.position - transform.position, Color.blue);       //Debug del raycast

        if (ray.transform != null && ray.transform.tag != "Player") i++;         //Cambiar punto de destino si se interpone un obstaculo en medio

        if (Vector2.Distance(puntosPatrulla[i % puntosPatrulla.Length].position, transform.position) > 0.4f)     //Movimiento del NPC hasta que llega al punto
        {
            direccion = new Vector2(puntosPatrulla[i % puntosPatrulla.Length].transform.position.x - transform.position.x, puntosPatrulla[i % puntosPatrulla.Length].transform.position.y - transform.position.y).normalized;
            transform.right = direccion;
            rb.velocity = transform.right * velocidadEstandar;
        }
        else CambiaEstado(Estados.patrulla);
    }

    public void CambiaEstado(Estados nuevoEstado)
    {
        estado = nuevoEstado;
    }

    public void PlayerPerdido()
    {
        CambiaEstado(Estados.volviendo);
        if (exclamationSprite != null) Destroy(exclamationSprite);
    }

    public void AbandonoZona()
    {
        CambiaEstado(Estados.volviendo);
        if (exclamationSprite != null) Destroy(exclamationSprite);
    }

    public void CambioPatron(Transform[] puntosnuevos)
    {
        i = 0;
        puntosPatrulla = puntosnuevos;
    }

    public bool Hellegado()
    {
        if (puntosPatrulla[puntosPatrulla.Length - 1] !=null && Vector2.Distance(transform.position, new Vector2(puntosPatrulla[puntosPatrulla.Length - 1].position.x, puntosPatrulla[puntosPatrulla.Length - 1].position.y)) < 1f)
        {
            return true;
        }
        else return false;
    }

    public Estados Estado()
    {
        return estado;
    }
    
    
}
