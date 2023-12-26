using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globo : MonoBehaviour
{
    public int id;
    public int numVecesInflado = 0;
    // Evento para explotar el globo y que se actualice la interfaz
    public EventHandler<int> ExplotarGlobo;

    private void Start()
    {
        // Se suscribe el método del observador (globo), al evento declarado en el sujeto (jugador)
        switch(id)
        {
            case 0:
                GameObject jugador = GameObject.FindGameObjectWithTag("Jugador");
                jugador.GetComponent<Jugador>().InflarGlobo += InflarGlobo;
                break;
            case 1:
                GameObject enemigo1 = GameObject.FindGameObjectWithTag("Enemigo 1");
                enemigo1.GetComponent<Enemigos>().InflarGlobo += InflarGlobo;
                break;
            case 2:
                GameObject enemigo2 = GameObject.FindGameObjectWithTag("Enemigo 2");
                enemigo2.GetComponent<Enemigos>().InflarGlobo += InflarGlobo;
                break;
            case 3:
                GameObject enemigo3 = GameObject.FindGameObjectWithTag("Enemigo 3");
                enemigo3.GetComponent<Enemigos>().InflarGlobo += InflarGlobo;
                break;
        }
    }

    private void Update()
    {
        ComprobarLimite();
    }

    private void InflarGlobo(object sender, int idPersonaje)
    {
        if(GestorGlobos.instancia.globoA && id==idPersonaje && id == 0)
        {
            numVecesInflado ++;
            transform.localScale *= 1.05f;
        }
        else if (GestorGlobos.instancia.globoB && id == idPersonaje && id == 1)
        {
            numVecesInflado++;
            transform.localScale *= 1.05f;
        }
        else if (GestorGlobos.instancia.globoC && id == idPersonaje && id == 2)
        {
            numVecesInflado++;
            transform.localScale *= 1.05f;
        }
        else if (GestorGlobos.instancia.globoD && id == idPersonaje && id == 3)
        {
            numVecesInflado++;
            transform.localScale *= 1.05f;
        }
    }

    private void ComprobarLimite()
    {
        if(numVecesInflado == GestorGlobos.instancia.limiteInflar)
        {
            Destroy(gameObject);
            ExplotarGlobo?.Invoke(this, id);
        }
    }

}
