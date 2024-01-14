using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globo : MonoBehaviour, IObserver, ISubject
{
    public int numVecesInflado = 0;
    private List<IObserver> observadores = new List<IObserver>();


    private void Start()
    {
        observadores= new List<IObserver>();
        // Se añade como observador del sujeto jugador
        GameObject jugador = GameObject.FindGameObjectWithTag("Jugador");
        jugador.GetComponent<ISubject>().AddObserver(gameObject.GetComponent<IObserver>());

    }

    private void Update()
    {
        ComprobarLimite();
    }

    private void InflarGlobo()
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
            NotifyObservers();
        }
    }

    public void UpdateState(int id)
    {
        InflarGlobo();
    }

    public void AddObserver(IObserver o)
    {
        observadores.Add(o);
    }

    public void RemoveObserver(IObserver o)
    {
        observadores.Remove(o);
    }

    public void NotifyObservers()
    {
        foreach(IObserver o in observadores)
        {
            o.UpdateState(1);
        }
    }
}
