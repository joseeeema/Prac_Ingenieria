using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private const float velocidad = 4f;

    // Update is called once per frame
    void Update()
    {
        if(!GestorJuguetes.instancia.juegoBloqueado)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (velocidad * Time.deltaTime));
            ComprobarPosicion();
        }
    }

    private void ComprobarPosicion()
    {
        if(transform.position.z >= 25)
        {
            Destroy(gameObject);
        }
    }
}
