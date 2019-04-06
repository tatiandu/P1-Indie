using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarLienzo : MonoBehaviour {

    public GameObject lienzoQueCambio;
    public GameObject lienzoNuevo;
    public void OnEnable()
    {
        lienzoQueCambio.SetActive(false);
        lienzoNuevo.SetActive(true);

    }
}
