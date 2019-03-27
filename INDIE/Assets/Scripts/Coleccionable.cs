using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coleccionable : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            Debug.Log("Coleccionable recogido");
            GameManager.instance.ColeccionableRecogido();
            Destroy(this.gameObject);
        }
    }
}
