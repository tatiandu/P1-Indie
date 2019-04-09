using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuGanar : MonoBehaviour {

    public Text ContadorColeccionables;

    private void Start()
    {
        ContadorColeccionables.text = "" + GameManager.instance.ColeccionablesTotales();
    }

    public void VolverAlMenu()
    {
        GameManager.instance.CargarEscena(0);
    }
}
