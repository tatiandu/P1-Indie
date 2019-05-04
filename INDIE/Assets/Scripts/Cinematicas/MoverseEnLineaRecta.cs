using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverseEnLineaRecta : MonoBehaviour
{

    Rigidbody2D rb;
    public Transform punto;
    public Animator anim;
    public Animator CanvasAnim;
    public GameObject convBuena, convMala,textoFin,joshua;
    public GameObject canvas;
    public int ColeccionablesMinimos,segundos;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("Final", segundos);

    }


    void Update()
    {
        if (transform.position.x <= punto.position.x)
        {
            rb.AddForce(new Vector2(500, 0));
            anim.SetBool("IsMoving", true);
            canvas.SetActive(false);
        }
        else
        {
            anim.SetBool("IsMoving", false);
            canvas.SetActive(true);
        }

    }
    void Final()
    {
        Debug.Log("sa inbokao");
        if (GameManager.instance.ColeccionablesTotales() > ColeccionablesMinimos)
        {
            joshua.SetActive(true);
            textoFin.SetActive(false);
            convBuena.SetActive(true);
            convMala.SetActive(false);

        }
        else
        {
            joshua.SetActive(true);
            textoFin.SetActive(false);
            convMala.SetActive(true);
            convBuena.SetActive(false);
        }
    }
    }
