using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Temporizador2 : MonoBehaviour
{
    [SerializeField]
    private TMP_Text cronometro;
    private int segundoInicial;
    public int segundosTranscurridos = 0;
    public int minutosTranscurridos = 0;

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
        if (segundoInicial != System.DateTime.Now.Second && !GestorJuguetes.instancia.juegoBloqueado)
        {
            segundosTranscurridos++;
            segundoInicial = System.DateTime.Now.Second;

            if (segundosTranscurridos == 60)
            {
                minutosTranscurridos++;
                segundosTranscurridos = 0;
            }
            if (segundosTranscurridos < 10)
            {
                if (minutosTranscurridos < 10)
                {
                    cronometro.text = "Tiempo resistido - 0" + minutosTranscurridos.ToString() + ":0" + segundosTranscurridos.ToString();
                }
                else
                {
                    cronometro.text = "Tiempo resistido - " + minutosTranscurridos.ToString() + ":0" + segundosTranscurridos.ToString();
                }
            }
            else
            {
                if (minutosTranscurridos < 10)
                {
                    cronometro.text = "Tiempo resistido - 0" + minutosTranscurridos.ToString() + ":" + segundosTranscurridos.ToString();
                }
                else
                {
                    cronometro.text = "Tiempo resistido - " + minutosTranscurridos.ToString() + ":" + segundosTranscurridos.ToString();
                }
            }

        }
    }

    public void Desaparecer()
    {
        cronometro.text = "";
    }
}
