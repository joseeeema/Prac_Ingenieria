using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jugador : MonoBehaviour, ISubject
{
    // El jugador es el sujeto del evento que infla el globo
    private List<IObserver> observadores = new List<IObserver>();

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
            NotifyObservers();
        }
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
        foreach(IObserver observer in observadores)
        {
            observer.UpdateState(0);
        }
    }
}
