using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIndicator : MonoBehaviour {

    public Transform target;
    public GameObject flecha;
	
	
	// Update is called once per frame
	void Update () {
        var dir = target.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        if (GameManager.instance.CaosActual() >= 100)
        {
            flecha.SetActive(true);
        }
	}
}
