using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Interfaz : MonoBehaviour
{
    public TMP_Text puntuacionA;
    public int puntuacion_A;

    public TMP_Text puntuacionB;
    public int puntuacion_B;

    public TMP_Text puntuacionC;
    public int puntuacion_C;

    public TMP_Text puntuacionD;
    public int puntuacion_D;


    // Start is called before the first frame update
    void Start()
    {
        GameObject globo = GameObject.FindGameObjectWithTag("Globo");
        globo.GetComponent<Globo>().ExplotarGlobo += ExplotarGlobo;

        GameObject jugador = GameObject.FindGameObjectWithTag("Jugador");
        jugador.GetComponent<Jugador>().InflarGlobo += InflarGlobo;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ExplotarGlobo(object sender, int id)
    {
        switch (id)
        {
            case 0:
                puntuacionA.text = "Puntuación: 0";
                GestorGlobos.instancia.globoA = false;
                break;
            case 1:
                puntuacionB.text = "Puntuación: 0";
                GestorGlobos.instancia.globoB = false;
                break;
            case 2:
                puntuacionC.text = "Puntuación: 0";
                GestorGlobos.instancia.globoC = false;
                break;
            case 3:
                puntuacionD.text = "Puntuación: 0";
                GestorGlobos.instancia.globoD = false;
                break;
        }
    }

    private void InflarGlobo(object sender, int id)
    {
        switch(id)
        {
            case 0:
                puntuacion_A++;
                puntuacionA.text = "Puntuación: "+puntuacion_A.ToString();
                break;
            case 1:
                puntuacion_B++;
                puntuacionB.text = "Puntuación: " + puntuacion_B.ToString();
                break;
            case 2:
                puntuacion_C++;
                puntuacionC.text = "Puntuación: " + puntuacion_C.ToString();
                break;
            case 3:
                puntuacion_D++;
                puntuacionD.text = "Puntuación: " + puntuacion_D.ToString();
                break;
        }
    }
}
