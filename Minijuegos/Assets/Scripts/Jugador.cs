using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    // El jugador es el sujeto del evento que infla el globo
    public EventHandler<int> InflarGlobo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Controles();
    }

    private void Controles()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            InflarGlobo?.Invoke(this, 0);
        }
    }
}
