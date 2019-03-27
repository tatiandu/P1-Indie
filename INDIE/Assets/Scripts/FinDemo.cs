using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinDemo : MonoBehaviour
{
    public GameObject miEnemigo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player")&&GameManager.instance.HasGanado())
        {
            GameManager.instance.MenuGanar();
        }
    }
}
