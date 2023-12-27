using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    [SerializeField]
    private TMP_Text cronometro;
    private int segundoInicial;
    private int segundosTranscurridos = 0;
    private int minutosTranscurridos = 0;

    // Start is called before the first frame update
    void Start()
    {
        segundoInicial = System.DateTime.Now.Second + 4;
    }

    // Update is called once per frame
    void Update()
    {
        Cronometro();
    }

    private void Cronometro()
    {
        if (segundoInicial != System.DateTime.Now.Second && !GestorLaberinto.instancia.juegoBloqueado)
        {
            segundosTranscurridos++;
            segundoInicial = System.DateTime.Now.Second;

            if(segundosTranscurridos==60)
            {
                minutosTranscurridos++;
                segundosTranscurridos = 0;
            }
            if(segundosTranscurridos<10)
            {
                if(minutosTranscurridos<10)
                {
                    cronometro.text = "Tiempo transcurrido - 0" + minutosTranscurridos.ToString() + ":0" + segundosTranscurridos.ToString();
                }
                else
                {
                    cronometro.text = "Tiempo transcurrido - " + minutosTranscurridos.ToString() + ":0" + segundosTranscurridos.ToString();
                }
            }
            else
            {
                if (minutosTranscurridos < 10)
                {
                    cronometro.text = "Tiempo transcurrido - 0" + minutosTranscurridos.ToString() + ":" + segundosTranscurridos.ToString();
                }
                else
                {
                    cronometro.text = "Tiempo transcurrido - " + minutosTranscurridos.ToString() + ":" + segundosTranscurridos.ToString();
                }
            }
            
        }
    }
}
