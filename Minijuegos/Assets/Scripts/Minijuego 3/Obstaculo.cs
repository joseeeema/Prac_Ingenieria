using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    private const float velocidad = 4f;
    private bool _finalCinta = false;

    // Update is called once per frame
    void Update()
    {
        if(!GestorJuguetes.instancia.juegoBloqueado)
        {
            if(!_finalCinta)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (velocidad * Time.deltaTime));
                ComprobarPosicion();
            }
            else
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - (velocidad * Time.deltaTime), transform.position.z);
            }
        }
    }

    private void ComprobarPosicion()
    {
        if(transform.position.z >= 27.5)
        {
            _finalCinta = true;
        }
    }
}
