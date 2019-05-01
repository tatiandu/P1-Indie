using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverCamara : MonoBehaviour
{
    public CinemachineCameraOffset offset;
    public float offsetX, offsetY, maxOffset;
    float valor;

    private void Start()
    {
        valor = 0;
    }
    void Update()
    {
        if (Input.GetButton("Mouse X") && Mathf.Abs(offset.m_Offset.x) < Mathf.Abs(maxOffset))
        {
            Debug.Log("x");
            offset.m_Offset.x += offsetX;
        }
        else if (Input.GetButton("Mouse X") && Mathf.Abs(offset.m_Offset.x) < Mathf.Abs(maxOffset))
        {
            Debug.Log("-x");
            offset.m_Offset.x -= offsetX;
        }
        else if (Input.GetButton("Mouse Y") && Mathf.Abs(offset.m_Offset.y) < Mathf.Abs(maxOffset))
        {
            Debug.Log("y");
            offset.m_Offset.y += offsetY;
        }
        else if (Input.GetButton("Mouse Y")  && Mathf.Abs(offset.m_Offset.y) < Mathf.Abs(maxOffset))
        {
            Debug.Log("-y");
            offset.m_Offset.y -= offsetY;
        }
        else
        {
            offset.m_Offset = Vector2.zero;
        }


    }
}
