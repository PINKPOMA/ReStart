using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseInput : MonoBehaviour
{
    
    void Update()
    { 
        float wheelInput = Input.GetAxis("Mouse ScrollWheel");

        if (wheelInput < 0)
        {
            transform.Translate(Vector3.up * 50000 * Time.deltaTime);
        }
        if (wheelInput > 0)
        {
            transform.Translate(Vector3.down * 50000 * Time.deltaTime);
        }
    }
}
