﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConoDeVision : MonoBehaviour {

    MovimientoEnemigo movEnemigo;
    TipoEnemigo tipoEnemigo;
    SpriteRenderer render;
    RaycastHit2D ray;
    GameObject playerGO;

    private void Start()
    {
        movEnemigo = GetComponentInParent<MovimientoEnemigo>();
        tipoEnemigo = GetComponentInParent<TipoEnemigo>();
        render = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerGO = collision.gameObject;
            ray = Physics2D.Raycast(transform.position, playerGO.transform.position - transform.position, Vector2.Distance(playerGO.transform.position, transform.position));  //Raycast
            Debug.DrawRay(transform.position, playerGO.transform.position - transform.position, Color.red);    //Debug del raycast

            if (ray.collider.tag == "Player" && tipoEnemigo.TipoDeEnemigo() == Disfraz.programador && (GameManager.instance.DisfrazJugador() == Disfraz.programador || GameManager.instance.DisfrazJugador() == Disfraz.ninguno)
            || tipoEnemigo.TipoDeEnemigo() == Disfraz.artista && (GameManager.instance.DisfrazJugador() == Disfraz.artista || GameManager.instance.DisfrazJugador() == Disfraz.diseñador || GameManager.instance.DisfrazJugador() == Disfraz.ninguno)
            || tipoEnemigo.TipoDeEnemigo() == Disfraz.diseñador && (GameManager.instance.DisfrazJugador() == Disfraz.diseñador || GameManager.instance.DisfrazJugador() == Disfraz.programador || GameManager.instance.DisfrazJugador() == Disfraz.artista || GameManager.instance.DisfrazJugador() == Disfraz.ninguno)
            || tipoEnemigo.TipoDeEnemigo() == Disfraz.personal || tipoEnemigo.TipoDeEnemigo() == Disfraz.lead)
            {
                Debug.Log("Player detected");
                movEnemigo.CambiaEstado(Estados.persecucion);
            }
        }
    }
    
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            playerGO = collision.gameObject;
            ray = Physics2D.Raycast(transform.position, playerGO.transform.position - transform.position, Vector2.Distance(playerGO.transform.position, transform.position));  //Raycast
            Debug.DrawRay(transform.position, playerGO.transform.position - transform.position, Color.red);    //Debug del raycast

            if (ray.collider.tag == "Player" && tipoEnemigo.TipoDeEnemigo() == Disfraz.programador && (GameManager.instance.DisfrazJugador() == Disfraz.programador || GameManager.instance.DisfrazJugador() == Disfraz.ninguno)
            || tipoEnemigo.TipoDeEnemigo() == Disfraz.artista && (GameManager.instance.DisfrazJugador() == Disfraz.artista || GameManager.instance.DisfrazJugador() == Disfraz.diseñador || GameManager.instance.DisfrazJugador() == Disfraz.ninguno)
            || tipoEnemigo.TipoDeEnemigo() == Disfraz.diseñador && (GameManager.instance.DisfrazJugador() == Disfraz.diseñador || GameManager.instance.DisfrazJugador() == Disfraz.programador || GameManager.instance.DisfrazJugador() == Disfraz.artista || GameManager.instance.DisfrazJugador() == Disfraz.ninguno)
            || tipoEnemigo.TipoDeEnemigo() == Disfraz.personal || tipoEnemigo.TipoDeEnemigo() == Disfraz.lead)
            {
                Debug.Log("Player detected");
                if (movEnemigo.Estado() != Estados.volviendo) movEnemigo.CambiaEstado(Estados.persecucion);
            }
        }
    }
    
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("PlayerLost");
            movEnemigo.PlayerPerdido();
        }
    }

    //// Activa el sprite
    //public void ActivarRender()
    //{
    //    render.enabled = true;
    //}

    //// Desactiva el sprite
    //public void DesactivarRender()
    //{
    //    render.enabled = false;
    //}
}
