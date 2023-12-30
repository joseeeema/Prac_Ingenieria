using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CintaTransportadora : MonoBehaviour
{
    private const float limite = 25f;
    private const float inicio = -45f;

    // Update is called once per frame
    void Update()
    {
        if(!GestorJuguetes.instancia.juegoBloqueado)
        {
            transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + (4f * Time.deltaTime));
            if(transform.position.z>=limite)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, inicio);
            }
        }
    }
}
