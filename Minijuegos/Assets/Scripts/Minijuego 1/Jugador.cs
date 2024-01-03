using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour
{
    // El jugador es el sujeto del evento que infla el globo
    public EventHandler<int> InflarGlobo;

    public GameObject[] skins;

    // Start is called before the first frame update
    void Start()
    {
        skins[ControladorJuego.instancia._personaje].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(!GestorGlobos.instancia.juegoBloqueado)
        {
            Controles();
        }
    }

    private void Controles()
    {
        if(Input.GetKeyDown(KeyCode.Space)) {
            InflarGlobo?.Invoke(this, 0);
        }
    }
}
