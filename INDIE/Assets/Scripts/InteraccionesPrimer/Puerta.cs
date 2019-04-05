using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puerta : MonoBehaviour {

    public GameObject Abierta, Cerrada;

    public void OnEnable()
    {
        Debug.Log("Pene");
        Abierta.SetActive(true);
        Cerrada.SetActive(false);
    }
}
