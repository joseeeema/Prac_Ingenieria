using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globo : MonoBehaviour
{
    public int numVecesInflado = 0;
    // Evento para explotar el globo y que se actualice la interfaz
    public EventHandler<int> ExplotarGlobo;

    private void Start()
    {
        // Se suscribe el método del observador (globo), al evento declarado en el sujeto (jugador)
        GameObject jugador = GameObject.FindGameObjectWithTag("Jugador");
        jugador.GetComponent<Jugador>().InflarGlobo += InflarGlobo;

    }

    private void Update()
    {
        ComprobarLimite();
    }

    private void InflarGlobo(object sender, int idPersonaje)
    {
        numVecesInflado ++;
        transform.localScale *= 1.03f;
    }

    private void ComprobarLimite()
    {
        if(numVecesInflado == GestorGlobos.instancia.limiteInflar)
        {
            GestorGlobos.instancia.Derrota();
            Destroy(gameObject, 0.1f);
            ExplotarGlobo?.Invoke(this, 0);
        }
    }

}
