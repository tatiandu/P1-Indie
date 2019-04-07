using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour {

    public GameObject parent;

    public void OnEnable()
        {
            Debug.Log("Coleccionable recogido");
            GameManager.instance.ColeccionableRecogido();
            Destroy(parent.gameObject);
        }
    }

