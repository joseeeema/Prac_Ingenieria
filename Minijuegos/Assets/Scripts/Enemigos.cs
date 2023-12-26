using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Enemigos : MonoBehaviour
{
    public int id;
    // Se va a categorizar la dificultad como 0(fácil), 1(normal) y 2(difícil)
    public int dificultad;
    public int objetivoInflar;
    public float tiempoEspera = 0.5f;
    public float contador = 0f;
    public int vecesInflado;

    public EventHandler<int> InflarGlobo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(contador>=tiempoEspera && vecesInflado<objetivoInflar)
        {
            contador = 0f;
            tiempoEspera = UnityEngine.Random.Range(0.35f, 0.7f);
            InflarGlobo?.Invoke(this, id);
            vecesInflado++;
        }
        contador += Time.deltaTime;
    }
}
