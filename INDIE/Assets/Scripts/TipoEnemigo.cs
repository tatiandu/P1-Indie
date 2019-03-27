using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TipoEnemigo : MonoBehaviour {

    public Disfraz tipo;
    SpriteRenderer rend;

    private void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        
        switch (tipo)
        {
            case Disfraz.artista:
                rend.color = Color.red;
                break;
            case Disfraz.programador:
                rend.color = Color.cyan;
                break;
            case Disfraz.diseñador:
                rend.color = Color.green;
                break;
            case Disfraz.personal:
                rend.color = Color.gray;
                break;
            case Disfraz.lead:
                rend.color = Color.yellow;
                break;
        }
    }

    public Disfraz TipoDeEnemigo()
    {
        return tipo;
    }

    /*private void Start()
    {
        if (Tipo==Disfraz.lead)
        {
            GameManager.instance.AvisoLead(this.gameObject.GetComponent<MoveEnemy>());
        }
    }*/
}
