using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Perder : MonoBehaviour {

    void Start()
    {

    }
    void Update()
    {

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy"))
        {

            GameManager.instance.Perder();
        }
    }
}
