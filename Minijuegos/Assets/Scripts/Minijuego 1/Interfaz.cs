using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interfaz : MonoBehaviour, IObserver
{
    public TMP_Text puntuacion;
    private int puntuacion_;

    private const int limiteTiempo = 30;
    private int segundosInicio;
    private int segundosTranscurridos = 0;

    public TMP_Text tiempo;

    private bool juegoFinalizado = false;


    // Start is called before the first frame update
    void Start()
    {
        GameObject globo = GameObject.FindGameObjectWithTag("Globo");
        globo.GetComponent<ISubject>().AddObserver(gameObject.GetComponent<IObserver>());

        GameObject jugador = GameObject.FindGameObjectWithTag("Jugador");
        jugador.GetComponent<ISubject>().AddObserver(gameObject.GetComponent<IObserver>());

        segundosInicio = System.DateTime.Now.Second + 4;
    }

    // Update is called once per frame
    void Update()
    {
        if(!juegoFinalizado)
        {
            Cronometro();
        }
    }

    private void ExplotarGlobo()
    {
        puntuacion.text = "Puntuaci�n: 0";
    }

    private void InflarGlobo()
    {
        puntuacion_++;
        puntuacion.text = "Puntuaci�n: " + puntuacion_.ToString();

    }

    private void Cronometro()
    {
        if(segundosInicio!= System.DateTime.Now.Second && !GestorGlobos.instancia.juegoBloqueado)
        {
            segundosTranscurridos++;
            segundosInicio = System.DateTime.Now.Second;
            tiempo.text = "Tiempo restante: "+(limiteTiempo-segundosTranscurridos).ToString();
        }
        if(segundosTranscurridos == 30)
        {
            juegoFinalizado = true;
            GestorGlobos.instancia.Victoria(puntuacion_);
        }
    }

    public void UpdateState(int id)
    {
        if(id==0)
        {
            InflarGlobo();
        }
        else
        {
            ExplotarGlobo();
        }
    }
}
