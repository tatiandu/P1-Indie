using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuertaLead : MonoBehaviour
{

    public GameObject Abierta, Cerrada, Lead;

    public void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject == Lead)
        {
            Abierta.SetActive(true);
            Cerrada.SetActive(false);
        }
    }
}
