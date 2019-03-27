using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioDisfraz : MonoBehaviour {
     public Disfraz miDisfraz;
     Disfraz disfrazAnterior;
    public GameObject artistaBoton;
    public GameObject programadorBoton;
    public GameObject personalBoton;
    public GameObject diseñadorBoton;
    GameObject poolDisfraz;
    

    void Start() {
        //inicia el juego sin disfraz, asigna pooldisfraz (gameObject vacío)
        miDisfraz = GameManager.instance.DisfrazJugador();
        poolDisfraz = GameObject.Find("PoolDisfraz");
    }

 

    public void MeCambio(Disfraz nuevoDisfraz)
    {
        //el disfraz que llevaba puesto pasa a ser el anterior, el del suelo pasa a ser el actual(ahora lo lleva puesto)
        disfrazAnterior = miDisfraz;
        miDisfraz = nuevoDisfraz;
        GameManager.instance.CambioDisfrazJugador(miDisfraz);
        //si llevaba anteriormente algún disfraz, este se instancia al lado de player

        switch (disfrazAnterior)
        {
            case Disfraz.artista:
                Instantiate<GameObject>(artistaBoton, new Vector2(transform.position.x, transform.position.y), transform.rotation, poolDisfraz.transform);
                break;
            case Disfraz.diseñador:
                Instantiate<GameObject>(diseñadorBoton, new Vector2(transform.position.x, transform.position.y), transform.rotation, poolDisfraz.transform);
                break;
            case Disfraz.personal:
                Instantiate<GameObject>(personalBoton, new Vector2(transform.position.x, transform.position.y), transform.rotation, poolDisfraz.transform);
                break;
            case Disfraz.programador:
                Instantiate<GameObject>(programadorBoton, new Vector2(transform.position.x, transform.position.y), transform.rotation, poolDisfraz.transform);
                break;

            }

        }
        
        
    }

